using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public  class Cart
    {
        public int Id { get; set; }
        public int ProcductId { get; set; } //FK
        public int Quantity { get; set; }
        decimal Price { get; set; }
        public Guid UserId { get; set; }
        //Đi Đến ENtity Product Để Xét Khóa Ngoại
        public Product Product { get; set; }

        public AppUser AppUser { get; set; }

    }
}
