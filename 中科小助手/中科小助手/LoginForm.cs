using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace 中科小助手
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            imgYzm.Image = ZkCommon.GetImageVCode();
        }

        private void imgYzm_Click(object sender, EventArgs e)
        {
            imgYzm.Image = ZkCommon.GetImageVCode();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string UserName = txtUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string Yzm = txtYzm.Text.Trim();
            string html = ZkCommon.Login(UserName, Password, Yzm);
            string value = ZkCommon.GetMatchVal(html, @"<script>alert\(""(?<val>.*?)""\);</script>");
            if (value == "")
            {
                string actionPage = ZkCommon.GetMatchVal(html, @"<form (.*) action=""(?<val>.*?).aspx""");
                if (actionPage.ToLower() == "index")
                {
                    //登录成功 
                    WinForm win = new WinForm();
                    this.Hide();
                    win.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
            }
            else
            {
                MessageBox.Show(value);
            }


        }
    }
}
