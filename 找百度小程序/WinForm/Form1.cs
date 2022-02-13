using BaiduSDK;
using Ku.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Ku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.gv_list.CellFormatting += Gv_list_CellFormatting;//当单元格的内容需要格式化以显示时发生。
            gv_list.CellContentClick += Gv_list_CellContentClick;//内容点击 
            gv_list.RowPostPaint += Gv_list_RowPostPaint;
            gv_list.DataBindingComplete += Gv_list_DataBindingComplete;
            gv_list.DefaultCellStyle.SelectionBackColor = Color.White;
            gv_list.DefaultCellStyle.SelectionForeColor = Color.Black;
            //gv_list.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.txtName.KeyDown += TxtName_KeyDown;
        }


        private void TxtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键
            {
                var keyword = txtName.Text;
                if (!UtilHelper.IsNull(keyword))
                {
                    DoSearch(keyword);
                }
                else
                {
                    //MessageBox.Show("请输入关键词！");
                }
            }
        }

        private void Gv_list_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                gv_list.RowHeadersWidth - 4,
                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gv_list.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gv_list.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);

        }
        private BindingList<ItemListItem> BindDataList = new BindingList<ItemListItem>();
        private int pageIndex = 10;
        private void btnMore_Click(object sender, EventArgs e)
        {
            msg("正在分页....");
            btnMore.Text = "正在分页...";
            new Thread(o =>
            {
                var keyword = txtName.Text;
                pageIndex = pageIndex + 10;
                var result = Mini_ProgramHelper.Get_Pagination_List(keyword, pageIndex);
                if (result.IsSuccess)
                {
                    if (result.hasNextPage)
                    {
                        foreach (var item in result.ItemList)
                        {
                            this.Invoke(new Action(() =>
                            {
                                BindDataList.Add(item);

                            }));

                        }
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            btnMore.Visible = false;

                        }));

                    }
                    bindData(false);
                }
                else
                {
                    pageIndex = pageIndex - 10;
                }

                this.Invoke(new Action(() =>
                {
                    btnMore.Text = "加载更多";

                }));

                msg("API地址=" + result.apuUrl);
                msg(result.Message);

            }).Start();
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            var gridList = BindDataList.OrderByDescending(o => o.userCount).ToList();
            BindDataList = new BindingList<ItemListItem>();
            foreach (var item in gridList)
            {
                BindDataList.Add(item);
            }
            gv_list.DataSource = BindDataList;

            msg("排序成功");
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtName.Text;
            if (!UtilHelper.IsNull(keyword))
            {
                DoSearch(keyword);
            }
            else
            {
                MessageBox.Show("请输入关键词！");
            }

        }

        private void DoSearch(string keyword)
        {
            msg("正在搜索数据...");
            this.Invoke(new Action(() =>
            {
                btnSearch.Text = "正在搜索数据...";
            }));

            BindDataList = new BindingList<ItemListItem>();
            pageIndex = 10;

            new Thread(o =>
            {
                var result = Mini_ProgramHelper.Get_FirstPage(keyword);
                if (result.IsSuccess)
                {
                    foreach (var item in result.ItemList)
                    {
                        BindDataList.Add(item);
                    }
                    bindData();
                }

                msg("API地址=" + result.apuUrl);
                msg(result.Message);

                this.Invoke(new Action(() =>
                {
                    btnMore.Visible = true;
                    btnSort.Visible = true;
                    btnSearch.Text = "搜索";
                }));
            }).Start();




        }

        private void bindData(bool isFist = true)
        {
            if (isFist)
            {
                this.Invoke(new Action(() =>
                {
                    //明细 
                    gv_list.AutoGenerateColumns = false; //禁止自动生成列，以下场景会用到：数据源的列超过需要展示的列
                    gv_list.DataSource = BindDataList;
                    gv_list.AutoResizeColumns();
                    gv_list.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                    gv_list.AllowUserToAddRows = false;

                }));
            }

        }
        private void Gv_list_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var gv = sender as DataGridView;

                if (e.Value == null)
                {
                    return;
                }
                var col = gv.Columns[e.ColumnIndex];
                var colName = col.Name;
                if (colName.Equals("icon"))
                {
                    string path = e.Value.ToString();
                    if (path != "System.Drawing.Bitmap")
                    {
                        e.Value = GetImage(path);
                    }
                }
                else if (colName.Equals("userCount"))
                {
                    long value = e.Value.ToInt64();
                    if (value > 10000)
                    {
                        e.Value = (value / 10000) + "万";
                    }
                }

                if (colName.Equals("description") || colName.Equals("logo_address") || colName.Equals("app_category"))
                {
                    col.CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                }


            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        private void Gv_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (gv_list.Columns[e.ColumnIndex].Name.Equals("web_index_url"))
                {
                    var web_index_url = this.gv_list.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    BrowserHelper.OpenBrowserUrl(web_index_url);
                }
            }
        }
        private void Gv_list_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //for (int i = 0; i < gv_list.Rows.Count; i++)
            //{
            //    int j = i + 1;
            //    gv_list.Rows[i].HeaderCell.Value = j.ToString();
            //}
            //var gv = sender as DataGridView; 

            //gv.Columns[0].CellTemplate.Style.WrapMode = DataGridViewTriState.True;

        }

        public System.Drawing.Image GetImage(string url)
        {
            var fileName = System.IO.Path.GetFileName(url);
            var path = AppDomain.CurrentDomain.BaseDirectory + "file_temp/" + fileName;

            if (!File.Exists(path))
            {
                //下载到本地
                var stream = WebRequest.Create(url).GetResponse().GetResponseStream();
                FileHelper.CreateDirectory(path);
                Image img = Image.FromStream(stream);
                img.Save(path);
            }

            return Image.FromFile(path);
        }


        private void msg(string message)
        {
            this.Invoke(new Action(() =>
            {
                txtMsg.Text += $"{DateTime.Now.ToDateStr()}：" + message + "\r\n";
                this.txtMsg.Focus();//获取焦点
                this.txtMsg.Select(this.txtMsg.TextLength, 0);//光标定位到文本最后
                this.txtMsg.ScrollToCaret();//滚动到光标处
            }));
        }
    }
}
