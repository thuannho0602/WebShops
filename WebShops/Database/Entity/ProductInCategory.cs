using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }//FK
        public int CategoryId { get; set; }//FK


        //Đi Đến Entity Product và Category Xét Khóa Ngoại
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
