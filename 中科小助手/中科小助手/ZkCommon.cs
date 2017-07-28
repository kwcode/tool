using BaseApiCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace 中科小助手
{
    public class ZkCommon
    {
        private static string domain = "http://login.zk71.com";//"http://192.168.1.104:7070"; 
        private static string __VIEWSTATE = "";
        private static string __EVENTVALIDATION = "";
        private static string __VIEWSTATEGENERATOR = "";
        public static System.Drawing.Image GetImageVCode()
        {
            try
            {
                string url = domain + "/ValidateCode.aspx?Nub=1&r=0." + DateTime.Now.ToString("yyyyMMdd");

                Stream stream = HttpRequestHelper.GetStream(url, Global.CookieCollection);
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

                string url = string.Format(domain + "/login.aspx");
                string html = HttpRequestHelper.HttpGet(url, Global.CookieCollection);
                SetViewState(html);
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("txtUserName", UserName);
                parameters.Add("txtPwd", Password);
                parameters.Add("CheckCode", Yzm);
                parameters.Add("__VIEWSTATE", __VIEWSTATE);
                parameters.Add("__EVENTVALIDATION", __EVENTVALIDATION);
                parameters.Add("__VIEWSTATEGENERATOR", __VIEWSTATEGENERATOR);
                parameters.Add("BtnOK.x", "70");
                parameters.Add("BtnOK.y", "6");
                string result = HttpRequestHelper.HttpPost(url, parameters, Global.CookieCollection);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region  产品相关
        /// <summary>
        /// 获取产品列表
        /// </summary>
        public static string GetProductList(int page)
        {
            string url = string.Format(domain + "/Manage/CorpProduct.aspx?page=" + page);
            string html = HttpRequestHelper.HttpGet(url, Global.CookieCollection);
            SetViewState(html);
            return html;
        }

        public static string RefreshProduct(List<string> chkSelectList)
        {
            string url = string.Format(domain + "/Manage/CorpProduct.aspx");

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("__VIEWSTATE", __VIEWSTATE);
            parameters.Add("__EVENTVALIDATION", __EVENTVALIDATION);
            parameters.Add("__VIEWSTATEGENERATOR", __VIEWSTATEGENERATOR);
            parameters.Add("ctl00$Middle$pager_input", "1");
            parameters.Add("__EVENTTARGET", "ctl00$Middle$Again1");
            foreach (string item in chkSelectList)
            {
                parameters.Add(item, "on");
            }
            string html = HttpRequestHelper.HttpPost(url, parameters, Global.CookieCollection);
            return html;
        }
        #endregion

        #region 设置基本信息

        public static void SetViewState(string html)
        {
            Match math = Regex.Match(html, "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"(?<val>.*?)\" />", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            string value = math.Groups["val"].Value;
            __VIEWSTATE = System.Web.HttpUtility.UrlEncode(value);
            math = Regex.Match(html, "<input type=\"hidden\" name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value=\"(?<val>.*?)\" />", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            __EVENTVALIDATION = System.Web.HttpUtility.UrlEncode(math.Groups["val"].Value);

            Match math3 = Regex.Match(html, "<input type=\"hidden\" name=\"__VIEWSTATEGENERATOR\" id=\"__VIEWSTATEGENERATOR\" value=\"(?<val>.*?)\" />", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            __VIEWSTATEGENERATOR = System.Web.HttpUtility.UrlEncode(math3.Groups["val"].Value);
        }
        #endregion


        #region 正则获取一个返回值
        public static string GetMatchVal(string html, string pattern)
        {
            Match math = Regex.Match(html, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            string value = math.Groups["val"].Value;
            return value;
        }
        #endregion
    }
}
