using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduSDK
{
    public class BaiduResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public bool hasNextPage { get; set; }

        public string apuUrl { get; set; }
        public List<ItemListItem> ItemList { get; set; }
    }
}
