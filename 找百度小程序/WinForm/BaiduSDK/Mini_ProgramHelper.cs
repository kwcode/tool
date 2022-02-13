
using Ku.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduSDK
{
    public class Mini_ProgramHelper
    {
        public static string Cookie { get; set; }
        public static string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";


        public static BaiduResult Get_FirstPage(string keyword)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BaiduResult baiduResult = new BaiduResult();
            var url = $"http://m.baidu.com/sf/vsearch?pd=mini_program&word={keyword}&atn=index";
            try
            {
                HttpHelper httpHelper = new HttpHelper();

                var hitem = new HttpItem()
                {
                    URL = url,
                    UserAgent = UserAgent,
                };
                var result = httpHelper.GetHtml(hitem);
                stopwatch.Stop();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Cookie = result.Cookie;
                    var html = result.Html;
                    var scriptList = RegexHelper.GetMatchList(html, "<script[^>]*?>(?<val>.*?)</script>");
                    if (scriptList.Count > 0)
                    {
                        foreach (var item in scriptList)
                        {
                            if (item.Contains(".smartapps.cn"))
                            {
                                var scriptContent = RegexHelper.GetMatchVal(item, "<script[^>]*?>(?<val>.*?)</script>");

                                var root = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonRoot>(scriptContent);
                                var itemList = root.data.itemList;

                                baiduResult.IsSuccess = true;
                                baiduResult.Message = $"搜索成功,耗时{stopwatch.Elapsed}";
                                baiduResult.ItemList = itemList;

                            }
                        }
                    }

                }
                else
                {
                    baiduResult.Message = $"搜索失败,耗时{stopwatch.Elapsed}";
                }
            }
            catch (Exception ex)
            {
                baiduResult.Message = ex.Message;
            }
            baiduResult.apuUrl = url;
            return baiduResult;
        }


        public static BaiduResult Get_Pagination_List(string keyword, int pageIndex = 10)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BaiduResult baiduResult = new BaiduResult();
            HttpHelper httpHelper = new HttpHelper();
            //https://m.baidu.com/sf/vsearch?pd=mini_program&word=企业&atn=index&pn=20&mod=1&data_type=json
            //Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36

            var url = $"https://m.baidu.com/sf/vsearch?pd=mini_program&word={keyword}&atn=index&pn={pageIndex}&mod=5&data_type=json";
            var hitem = new HttpItem()
            {
                Cookie = Cookie,
                URL = url,
                UserAgent = UserAgent,
            };
            var result = httpHelper.GetHtml(hitem);

            stopwatch.Stop();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var html = result.Html;
                var root = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonRoot>(html);
                var itemList = root.data.itemList;
                baiduResult.ItemList = itemList;
                baiduResult.IsSuccess = true;
                baiduResult.Message = $"API成功,耗时{stopwatch.Elapsed}";
                baiduResult.hasNextPage = root.data.hasNextPage;
            }
            else
            {
                baiduResult.Message = $"API失败，接口={url},耗时{stopwatch.Elapsed}";
            }
            baiduResult.apuUrl = url;
            return baiduResult;
        }


    }
}
