using Demo.DataBase.Emum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowonHome { get; set; }
        public int? ParentId { get; set; } 
        //Chuyền Đến  file DataBase.Emum;
        public Status Status { get; set; }
        //Dùng Để Trỏ Đến ProductInCategory
        public List<ProductInCategory> ProductInCategories { get; set; }
    }
}
