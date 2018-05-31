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
    public class OrdersModel : PageModel
    {

        private readonly CatContext _db;

        private readonly UserManager<ApplicationUser> _UserManager;

        public OrdersModel(UserManager<ApplicationUser> UserManager, CatContext db)
        {
            _UserManager = UserManager;
            _db = db;
        }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public async Task OnGetAsync()
        {
            // https://stackoverflow.com/questions/45362495/nested-foreach-loop-in-asp-net-mvc-core-nullreferenceexception
            Orders = await _db.Orders.Include(order => order.Items).Where(order => order.OwnerID == _UserManager.GetUserId(User)).ToListAsync();
        }
    }
}
