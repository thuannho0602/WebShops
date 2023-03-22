using Demo.DataBase.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal Originalprice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreacted { get; set; }
        public bool IsFeaatured { get; set; }

        // Dùng Để trỏ Đến ProductInCategory ,OrderDatail
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<OrderDatail> OrderDatails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
