using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using via_web_application.Services;

namespace via_web_application {

  public static class DbInitializer {
    public static void Initialize(CatContext context) {

      context.Database.EnsureCreated();


      if (context.Cats.Any()) {
        return; // DB has been seeded
      }

      var cats = new Cat[] {
        new Cat {
          Name = "Murka", 
          Color = "Black", 
          Price = 90.20M, 
          Picture = "https://i.imgur.com/AD3MbBi.jpg",
          Birthdate = new DateTime(2015, 10, 4),
          Breed = "Aegean cat",
          Weight = 1.3M,
        },
        new Cat {
          Name = "Tom", 
          Color = "Grey", 
          Price = 49.20M,
          Picture = "https://i.imgur.com/4AAyzBX.jpg",
          Birthdate = new DateTime(2013, 5, 4),
          Breed = "American Curl",
          Weight = 1.5M
        },
        new Cat {
          Name = "Mini", 
          Color = "White", 
          Price = 1700.20M,
          Picture = "https://i.imgur.com/6qVIp0P.jpg",
          Birthdate = new DateTime(2015, 10, 3),
          Breed = "Tiger",
          Weight = 59.9M
        },
        new Cat {
          Name = "Jarry", 
          Color = "Brown", 
          Price = 17.20M,
          Picture = "https://i.imgur.com/3rYHhEu.jpg",
          Birthdate = new DateTime(2013, 6, 4),
          Breed = "Havana Brown",
          Weight = 1.9M
        }
      };


      foreach (Cat cat in cats) {
          context.Cats.Add(cat);
      }

      context.SaveChanges();

    }

            // https://stackoverflow.com/questions/42471866/how-to-create-roles-in-asp-net-core-and-assign-them-to-users
    public static void InitializeRoles(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager )
    {

      Task<IdentityResult> roleResult;
      string email = "admin@admin.com";

      //Check that there is an Administrator role and create if not
      Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
      hasAdminRole.Wait();

      if (!hasAdminRole.Result)
      {
          roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
          roleResult.Wait();
      }

      //Check if the admin user exists and create it if not
      //Add to the Administrator role

      Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
      testUser.Wait();

      if (testUser.Result == null)
      {
          ApplicationUser administrator = new ApplicationUser();
          administrator.Email = email;
          administrator.UserName = email;

          Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "123456789");
          newUser.Wait();

          if (newUser.Result.Succeeded)
          {
              Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
              newUserRole.Wait();
          }
      }

    }
  }
}