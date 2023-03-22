using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class OrderDatail
    {
        public int OrderId { get; set; }//FK
        public int ProductId { get; set; }//Fk
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //Di Đến Enriry Product và Order Xét Khóa Ngoại
        public Product Product { get; set; }
        public Order Order { get; set; }

        // Dùng Để trỏ Đến Order
        public List<Order> Orders { get; set; }
    }
}
