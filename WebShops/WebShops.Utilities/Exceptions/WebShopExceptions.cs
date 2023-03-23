using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShops.Utilities.Exceptions
{
    public class WebShopExceptions: Exception
    {
        public WebShopExceptions()
        {

        }
        public WebShopExceptions(string message) : base(message)
        {

        }
        public WebShopExceptions(string message,Exception inner) : base(message, inner)
        {

        }
    }
}
