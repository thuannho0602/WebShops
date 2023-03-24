using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.ViewModels.Common;

namespace WebShop.ViewModels.Catalog.Productt
{
    public class GetPublictProductPadingRequest : PadgingRequestBase
    {
       // public string LanguageId { get; set; }
        //public string Keyword { get; set; }
        public int? CatogeryId { get; set; }
    }
}
