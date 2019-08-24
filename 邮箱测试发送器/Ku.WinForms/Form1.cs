using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Ku.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var port = Convert.ToInt32(txtPort.Text);
                SendEmail(txtUserName.Text.Trim(), txtPassword.Text, txtSmtpServer.Text, port, txtToEmail.Text, "测试主题", "测试内容");

                MessageBox.Show("发送成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #region 发送邮件
        public void SendEmail(string userName, string password, string smtpServer, int port, string toEmail, string subject, string content)
        {
            string fromNickName = "测试昵称";//自定义发件人
            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(userName, password);//用户名和密码
            smtpClient.Port = port;//阿里云建议 邮件默认的
            //smtpClient.Timeout = 10000;//5秒
            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(userName, fromNickName);
            mailMessage.To.Add(new MailAddress(toEmail));

            //MailMessage mailMessage = new MailMessage(EmailUserName, toEmail); // 发送人和收件人
            mailMessage.Subject = subject;//主题
            mailMessage.Body = content;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级
            smtpClient.Send(mailMessage); // 发送邮件

        }
        #endregion
    }
}
