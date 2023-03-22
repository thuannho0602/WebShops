﻿using Demo.DataBase.Emum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class Promotion
    {
        public int Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public int? DiscountPrecent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string ProductIds { get; set; }
        public string ProducCategory { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
    }
}
