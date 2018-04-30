using System;

namespace via_web_application.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }//TODO type?
        public string Phone { get; set; }//TODO type?
        public string Password { get; set; }//TODO type?
        public string Type { get; set; }//admin/ordinaryuser
        public DateTime Registered { get; set; } //TODO consideration...
    }
}