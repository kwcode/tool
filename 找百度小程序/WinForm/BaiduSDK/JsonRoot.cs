using System;
using System.Collections.Generic;
using System.Text;

namespace BaiduSDK
{
    //如果好用，请收藏地址，帮忙分享。
    public class Source
    {
        /// <summary>
        /// 
        /// </summary>
        public string logo { get; set; }
        /// <summary>
        /// 拉卡拉收款码
        /// </summary>
        public string source { get; set; }
    }

    public class Xcx_params
    {
        /// <summary>
        /// 
        /// </summary>
        public string xcx_appkey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xcx_from { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xcx_path { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string xcx_url { get; set; }
    }

    public class ItemListItem
    {
        /// <summary>
        /// 金融业_支付业务
        /// </summary>
        public string app_category { get; set; }
        /// <summary>
        /// 四川云考拉科技有限公司
        /// </summary>
        public string customer_name { get; set; }
        /// <summary>
        /// 个人及商用收款二维码免费申请办理！
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string excellentXcx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string genre { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 拉卡拉收款码
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string official_flag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string web_index_url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gen_timestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int userCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Source source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Xcx_params xcx_params { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string failTcUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string softwarePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string scheme { get; set; }
    }

    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<ItemListItem> itemList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string smartApp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string willOpenBox { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string noresult { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nodatalist { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool hasNextPage { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string aquery { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wiseurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isBaiduApp { get; set; }
    }

    public class Errmsg
    {
    }

    public class JsonRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public int errno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Errmsg errmsg { get; set; }
    }


}
