using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace via_web_application {

  public static class DbInitializer {
    public static void Initialize(CatContext context) {

      context.Database.EnsureCreated();


      if (context.Cats.Any()) {
        return; // DB has been seeded
      }

      var cats = new Cat[] {
        new Cat {Name = "Murka", Color = "Black", Price = 90.20M},
        new Cat {Name = "Tom", Color = "Grey", Price = 49.20M},
        new Cat {Name = "Jarry", Color = "White", Price = 17.20M}
      };


      foreach (Cat cat in cats) {
          context.Cats.Add(cat);
      }

      context.SaveChanges();

    }


  }
}