using BaseApiCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TPing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoSearch();

        }

        private void DoSearch()
        {
            try
            {
                string hostName = txtHost.Text.Trim();
                if (string.IsNullOrEmpty(hostName))
                {
                    MessageBox.Show("请输入域名");
                    return;
                }
                hostName = hostName.Replace("http://", "").Replace("/", "");

                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(hostName);
                System.Text.StringBuilder sb = new StringBuilder();
                sb.Append("当前网站:[" + hostName + "]\r\n");
                sb.Append("IP地址:");
                List<string> ipList = new List<string>();
                foreach (IPAddress item in host.AddressList)
                {
                    ipList.Add(item.ToString());
                    sb.Append(item.ToString() + "\r\n");
                }
                if (host.HostName != "")
                {
                    sb.Append("DNS 名称=" + host.HostName);
                }
                txtResult.Text = sb.ToString();
                IpSearch(ipList);

            }
            catch (Exception ex)
            {
                txtResult.Text = ex.ToString();
            }
        }
        private void IpSearch(List<string> ipList)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var item in ipList)
            {
                try
                {

                    string ip = item;
                    string html = HttpRequestHelper.HttpGet(@"http://www.baidu.com/s?wd=" + ip, Encoding.UTF8);
                    html = html.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");

                    string pattern = @"<div class=""c-span21 c-span-last op-ip-detail"">(?<val>.*?)</div>";
                    Match math = Regex.Match(html, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    string value = math.Groups["val"].Value;
                    string val2 = Regex.Replace(value, "<[^>]+>", "");

                    sb.Append(val2.Replace("&nbsp;", "").Trim() + "\r\n");

                }
                catch (Exception ex)
                {

                }
            }
            txtIpMsg.Text = sb.ToString();
        }

        private void txtHost_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode;
            if (key == Keys.Enter)
            {
                DoSearch();
            }
        }
    }
}
