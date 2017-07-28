//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Windows.Forms;

//namespace 中科小助手
//{
//    class testest
//    {
//        private void PostByWebRequest(string strPostValue)
//        {
//            try
//            {
//                string URI = "http://localhost:2026/webform1.aspx/";
//                HttpWebRequest request = WebRequest.Create(URI) as HttpWebRequest;
//                request.Method = "GET"; request.KeepAlive = true;
//                request.CookieContainer = cookieContainer;
//                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
//                System.IO.Stream responseStream = response.GetResponseStream();
//                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
//                //返回的页面html文本                  string srcString = reader.ReadToEnd();             
//                //VeiwState                                
//                string viewStateFlag = "id=\"__VIEWSTATE\" value=\"";
//                int len1 = srcString.IndexOf(viewStateFlag) + viewStateFlag.Length;
//                int len2 = srcString.IndexOf("\"", len1);
//                string viewState = srcString.Substring(len1, len2 - len1);
//                //EventValidation                                  
//                string eventValidationFlag = "id=\"__EVENTVALIDATION\" value=\"";
//                len1 = srcString.IndexOf(eventValidationFlag) + eventValidationFlag.Length;
//                len2 = srcString.IndexOf("\"", len1);
//                string eventValidation = srcString.Substring(len1, len2 - len1);
//                //编码                 
//                viewState = System.Web.HttpUtility.UrlEncode(viewState);
//                eventValidation = System.Web.HttpUtility.UrlEncode(eventValidation);
//                //这里可以通过抓包工具获得poststring.记得中文需要UrlEncode编码。    
//                string formatString = "DropDownList1={0}&amp;Button1={1}&amp;__VIEWSTATE={2}&amp;__EVENTVALIDATION={3}";
//                string postString = string.Format(formatString, strPostValue, "Do PostBack", viewState, eventValidation);
//                byte[] postData = Encoding.UTF8.GetBytes(postString);
//                URI = "http://localhost:2026/webform1.aspx/";                  //POST        
//                request = WebRequest.Create(URI) as HttpWebRequest;
//                request.Method = "POST";
//                request.KeepAlive = false;
//                request.ContentType = "application/x-www-form-urlencoded";
//                request.CookieContainer = cookieContainer;
//                request.ContentLength = postData.Length;
//                System.IO.Stream outputStream = request.GetRequestStream();
//                outputStream.Write(postData, 0, postData.Length);
//                outputStream.Close();
//                response = request.GetResponse() as HttpWebResponse;
//                responseStream = response.GetResponseStream();
//                reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
//                srcString = reader.ReadToEnd();
//            }
//            catch (Exception ex)
//            {
//                string msg = ex.Message;
//                MessageBox.Show(ex.Message);
//            }
//        }
//    }

//}
