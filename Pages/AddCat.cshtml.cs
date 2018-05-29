using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace via_web_application.Pages
{
    public class AddCatModel : PageModel
    {

       private readonly CatContext _db;

        public AddCatModel(CatContext db)
        {
            _db = db;
        }


        [BindProperty]
        public Cat cat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Cats.Add(cat);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
        // public void OnGet()
        // {

        // }
    }
}
