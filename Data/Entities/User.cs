using System;
using System.ComponentModel.DataAnnotations;

namespace via_web_application {
  public class User {
    public int ID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string Email { get; set; }

    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Type { get; set; }

  }
}