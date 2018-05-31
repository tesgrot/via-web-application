using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

/*
        
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        } */
        private readonly CatContext _db;

        private readonly UserManager<ApplicationUser> _UserManager;

        public StoreModel(UserManager<ApplicationUser> UserManager, CatContext db)
        {
            _UserManager = UserManager;
            _db = db;
        }

        public IList<Cat> Cats { get; set; } = new List<Cat>();

        public async Task OnGetAsync()
        {
            Cats = await _db.Cats.Where(cat => cat.Order == null).ToListAsync();
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string Name { get; set; }

            public string Address { get; set; }

            public Dictionary<int, bool> Items { get; set; } = new Dictionary<int, bool>();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order order = new Order();
            //  {
            //     Name = Input.Name, 
            //     Address = Input.Address
            // };
            order.Name = Input.Name;
            order.Address = Input.Address;
            
            order.Items = new Collection<Cat>();

            foreach(KeyValuePair<int, bool> entry in Input.Items)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value == true) {

                    Cat item = _db.Cats.FirstOrDefault(t => t.ID == entry.Key);
                    order.Items.Add(item);
                }
            }

            order.OwnerID = _UserManager.GetUserId(User);

            order.Status = "New";

            order.Date = DateTime.Now;

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Index");


        }

    }
}
