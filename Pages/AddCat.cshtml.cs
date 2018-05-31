using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using via_web_application.Models;

namespace via_web_application.Pages
{
    public class AddCatModel : PageModel
    {

        private readonly CatContext _db;
        private readonly IHostingEnvironment _appEnvironment;

        public AddCatModel(CatContext db, IHostingEnvironment environment)
        {
            _db = db;
            _appEnvironment = environment;
        }


        [BindProperty]
        public Cat cat { get; set; }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            _db.Cats.Add(cat);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }


    }
}
