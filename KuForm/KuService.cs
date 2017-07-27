using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Ku
{
    public class KuService : MessageProc
    {
        Thread taskThread = null;
        public void Start()
        {
            msg("服务启动");
            taskThread = new Thread(DoThreadTask);
            taskThread.Start();
        }


        internal void Stop()
        {
            msg("关闭服务...");
            if (taskThread != null)
            {
                taskThread.Abort();
                taskThread = null;
            }
        }

        private void DoThreadTask(object obj)
        {
            try
            {

                Process p = new Process();

                p.StartInfo.FileName = "cmd.exe ";

                p.StartInfo.UseShellExecute = false;

                p.StartInfo.RedirectStandardInput = true;

                p.StartInfo.RedirectStandardOutput = true;

                p.StartInfo.RedirectStandardError = true;

                p.StartInfo.CreateNoWindow = true;

                p.Start();
                p.StandardInput.WriteLine(" netstat -a -n ");
                //p.StandardInput.WriteLine("ping   172.16.1.1 ");

                p.StandardInput.WriteLine("exit ");

                string strRst = p.StandardOutput.ReadToEnd();

                p.WaitForExit();

                msg(strRst);

            }

            catch (Exception err)
            {

                msg(err.Message);   //显示错误信息。 

            }
        }
    }
}
