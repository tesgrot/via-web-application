using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace via_web_application.Controllers
{

  // http://localhost:5000/api/cat
  
  [Route("api/cat")]
  public class CatController : Controller
  {

    private readonly CatContext _context;

    public CatController(CatContext context)
    {
      _context = context;
    }

    // For now can only get all cats
    // GET api/cat
    [HttpGet]
    public IEnumerable<Cat> Get()
    {
      return _context.Cats.ToList();
    }

  }
}
