using via_web_application.Models;
using System.Collections.Generic;
using System;

namespace via_web_application.Models
{
    public class Order
    {
        public int ID { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}