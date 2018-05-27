using System;

namespace via_web_application.Models
{
    public class Cat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }//TODO type?
    }
}