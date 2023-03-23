using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.ViewModels.Common
{  
    public class PadgingRequestBase
    {
        public int PageIndext { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}
