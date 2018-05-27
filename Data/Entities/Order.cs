using System;
using System.Collections.Generic;

namespace via_web_application {
  public class Order {
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
    public string Status { get; set; }
    public ICollection<OrderItem> Items { get; set; }

    
  }
}