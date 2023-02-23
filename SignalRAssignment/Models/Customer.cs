﻿using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? Password { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
