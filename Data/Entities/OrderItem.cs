namespace via_web_application {
  public class OrderItem {
    public int ID { get; set; }
    public Cat cat { get; set; } 
    public int quantity { get; set; }
    public Order order { get; set; }
    
  }
}