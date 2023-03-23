using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.Common;

namespace WebShop.ViewModels.Catalog.Productt
{
    public class GetManageProductPagingRequest:PadgingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
