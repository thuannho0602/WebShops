using Demo.DataBase.Emum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public  class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public string ShipPhoneNumber { get; set; }
        public Guid UserId { get; set; }
        //Chuyền Đến  file DataBase.Emum;
        public OrderStatus OrderStatus { get; set; }

        // Dùng Để trỏ Đến OrderDatail
        public List<OrderDatail> OrderDatails { get; set; }
        public AppUser AppUser { get; set; }
    }
}
