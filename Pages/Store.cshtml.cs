using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using via_web_application;
using via_web_application.Services;

namespace via_web_application.Pages
{
    public class StoreModel : PageModel
    {

        private readonly CatContext _db;

        public StoreModel(CatContext db)
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
    }
}
