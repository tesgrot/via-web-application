using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace via_web_application.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CatContext _db;

        public IndexModel(CatContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Cat cat { get; set; }

        public IList<Cat> Cats { get; set; } = new List<Cat>();
        public async Task OnGetAsync()
        {
            Cats = await _db.Cats.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cat = await _db.Cats
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.ID == id);

            if (cat == null)
            {
                return NotFound();
            }

            try
            {
                _db.Cats.Remove(cat);
                await _db.SaveChangesAsync();
                return RedirectToPage("./About");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id = id, saveChangesError = true });
            }
        }
        // public async ActionResult OnGetDeleteAsync(int id)
        // {
        //     // if (id != null)
        //     // {
        //     // var data = (from cat in _db.Cats
        //     //             where cat.ID == id
        //     //             select cat).SingleOrDefault();

        //     _db.Cats.Remove(id);
        //     await _db.SaveChangesAsync();
        //     // }
        //     return RedirectToPage("AllCustomer");
        // }

        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     _db.Cats.Add(cat);
        //     await _db.SaveChangesAsync();
        //     return RedirectToPage("/Index");
        // }
    }
}
