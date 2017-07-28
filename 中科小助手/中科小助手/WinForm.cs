using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace 中科小助手
{
    public partial class WinForm : Form
    {
        public WinForm()
        {
            InitializeComponent();
            this.FormClosing += WinForm_FormClosing;

        }

        void WinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                }
            }
            catch { }
        }
        private string productHtml = "";
        private void Init()
        {
            productHtml = ZkCommon.GetProductList(1);
        }

        private void btnRefreshProduct_Click(object sender, EventArgs e)
        {
            List<string> chkSelectList = new List<string>();
            Match m = Regex.Match(productHtml, "<input id=\"(?<val>.*?)\" type=\"checkbox\" name=\"(?<val>.*?)\" />", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            while (m.Success)
            {
                string value = m.Groups["val"].Value;
                chkSelectList.Add(value);
                m = m.NextMatch();
            }
            string html = ZkCommon.RefreshProduct(chkSelectList);
            Match math = Regex.Match(productHtml, "<script>(?<val>.*?)</script>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            string value2 = math.Groups["val"].Value;
            MessageBox.Show(value2);
        }

        private void btnRefreshPage_Click(object sender, EventArgs e)
        {
            productHtml = ZkCommon.GetProductList(1);
        }
        Thread thread = null;
        private void btnAutoRefreshProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                }
            }
            catch { }
            thread = new Thread(DoTask);
            thread.Start();
        }

        private void DoTask()
        {
            int max = Convert.ToInt32(txtMaxPage.Text);
            int page = Convert.ToInt32(txtPage.Text);
            while (page < max)
            {
                productHtml = ZkCommon.GetProductList(page);
                List<string> chkSelectList = new List<string>();
                Match m = Regex.Match(productHtml, "<input id=\"(?<val>.*?)\" type=\"checkbox\" name=\"(?<val>.*?)\" />", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                while (m.Success)
                {
                    string value = m.Groups["val"].Value;
                    chkSelectList.Add(value);
                    m = m.NextMatch();
                }


                string html = ZkCommon.RefreshProduct(chkSelectList);
                Match math = Regex.Match(html, @"<script[^>]*?>alert\(['|""](?<val>.*?)['|""]\)[;?](?<val2>.*?)</script>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                string value1 = math.Groups["val"].Value;
                string value2 = math.Groups["val2"].Value;
                if (value2 != "")
                {
                    this.Invoke(new Action(() =>
                    {
                        txtMsg.Text = value1 + "\r\n当前已经刷新到(" + page + ")页\r\n正在刷新下一页";
                    }));
                }
                else
                {
                    this.Invoke(new Action(() =>
                    {
                        txtMsg.Text = value1 + "\r\n 当前刷新到（" + page + "）页\r\n已经停止刷新";
                    }));
                    break;
                }
                page++;
                int time = Convert.ToInt32(txtTime.Text);
                Thread.Sleep(time * 1000);
            }
        }
        #region 重新登录

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                }
            }
            catch { }

            Form1 win = new Form1();
            this.Hide();
            win.Show();
        }

        #endregion


    }

}
