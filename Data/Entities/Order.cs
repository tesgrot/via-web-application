using System;
using System.Collections.Generic;

namespace via_web_application
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<Cat> Items { get; set; }
        
        // user ID from AspNetUser table.
        public string OwnerID { get; set; }


    }
}