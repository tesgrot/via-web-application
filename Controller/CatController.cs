using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace via_web_application.Controllers
{

    // http://localhost:5000/api/cat

    [Route("api/[controller]")]
    public class CatController : Controller
    {

        private readonly CatContext _context;

        public CatController( CatContext CatContext)
        {
            _context = CatContext;
        }

        // For now can only get all cats
        // GET api/cat
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return _context.Cats.OrderBy(p => p.Name).ToList();
        }
    }
}
