using System;
using System.ComponentModel.DataAnnotations;

namespace via_web_application {
  public class Cat {

    public int ID { get; set; }
    
    [StringLength(20, MinimumLength = 2)]
    [Required]
    public string Name { get; set; }

     public string Color { get; set; }

    [Range(0, 100)]
    [DataType(DataType.Currency)]
    // [Required]
    public decimal Price { get; set; }
    public DateTime Birthdate { get; set; }
    public char Sex { get; set; }

    public string Breed { get; set; }

    public decimal Weight { get; set; }

    public string Picture { get; set; }

  }
}