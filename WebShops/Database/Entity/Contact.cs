using Demo.DataBase.Emum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { set; get; }

        //Chuyền Đến  file DataBase.Emum;
        public Status Status { get; set; }
    }
}
