using Ku;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KuForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            this.FormClosing += Form1_FormClosing;
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logs.write("UnknownError", e.ExceptionObject.ToString());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logs.write("UnknownError", e.Exception.ToString());
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Text = "正在关闭中...";
            if (wtjService != null)
            {
                wtjService.Stop();
                md = null;
            }

            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
        KuService wtjService = null;
        private MessageDisplay md = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            wtjService = new KuService();
            md = new MessageDisplay(txtOutputMsg);
            wtjService.noticeEvent += md.msg;
            wtjService.Start();
        }
    }
}
