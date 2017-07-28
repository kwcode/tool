using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class LogCommon
{
    private static object writeLogObj = new object();
    #region 写日志
    /// <summary>
    /// 写日志
    /// </summary>
    /// <param name="logFileName">日志文件名或文件夹名 log.txt /log/log.txt</param>
    /// <param name="message">日志信息(已经包含时间;)</param>
    public static void WriteLog(string logFileName, string message)
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string logPath = baseDir + logFileName;
            string ext = System.IO.Path.GetExtension(logPath);
            if (string.IsNullOrEmpty(ext))
            {
                logPath += ".txt";
            }
            string dirName = System.IO.Path.GetDirectoryName(logPath);
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);

            lock (writeLogObj)
            {
                StreamWriter mySw = new StreamWriter(logPath, true, ASCIIEncoding.UTF8);
                mySw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss") + "：" + message);
                mySw.Flush();
            }
        }
        catch (Exception ex)
        {
            WriteLog("log_Error.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ssss") + "：" + ex.ToString());
        }
    }
    #endregion

}
