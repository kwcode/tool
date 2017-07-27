using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace 中科小助手
{
    public class ZkCommon
    {
        private static string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
        static HttpItem _Item;
        static HttpResult _Result;
        public static System.Drawing.Image GetImageVCode()
        {
            try
            {
                //初始化
                HttpHelper http = new HttpHelper();
                HttpItem httpItem = new HttpItem()
                {
                    URL = "http://login.zk71.com/ValidateCode.aspx?Nub=1&r=0." + DateTime.Now.ToString("yyyyMMdd"),
                    Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                    UserAgent = _UserAgent,
                    Cookie = Global.Cookie,
                    ResultType = ResultType.Byte,
                    ContentType = "application/x-www-form-urlencoded"
                };


                HttpResult result = http.GetHtml(httpItem);
                //item.ResultType = ResultType.Byte;
                MemoryStream stream = new MemoryStream(result.ResultByte);
                Image img = Image.FromStream(stream, true);
                return img;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region 登录

        public static string Login(string UserName, string Password, string Yzm)
        {
            try
            {

                string url = string.Format("http://login.zk71.com/login.aspx");
                string postdata = string.Format("txtUserName:{0},txtPwd:{1},CheckCode:{2}", UserName, Password, Yzm);
                //string.Concat(new string[]
                //{

                //    "{\"txtUserName\":\"", 
                //    UserName, 
                //    "\",\"txtPwd\":", 
                //    Password, 
                //    ",\"CheckCode\":\"\",\""+Yzm+"\":\"",  
                //    "\"}"
                //}, true);
                _Item = new HttpItem
                {
                    URL = url,
                    Accept = "application/javascript, */*;q=0.8",
                    //Referer = "https://ui.ptlogin2.qq.com/cgi-bin/login?daid=164&target=self&style=16&mibao_css=m_webqq&appid=501004106&enable_qlogin=0&no_verifyimg=1&s_url=http%3A%2F%2Fw.qq.com%2Fproxy.html&f_url=loginerroralert&strong_login=1&login_state=10&t=20131024001",
                    UserAgent = _UserAgent,
                    Cookie = Global.Cookie,
                    ContentType = "application/x-www-form-urlencoded",
                    Postdata = postdata
                };
                HttpHelper _Http = new HttpHelper();
                _Result = _Http.GetHtml(_Item);
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
