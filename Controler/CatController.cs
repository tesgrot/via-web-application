using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace via_web_application.Controllers
{

  // http://localhost:5000/api/cat
  
  [Route("api/[controller]")]
  public class CatController : Controller
  {

    private readonly CatRepository catRepo;

    public CatController(CatRepository repo)
    {
      catRepo = repo;
    }

    // For now can only get all cats
    // GET api/cat
    [HttpGet]
    public IEnumerable<Cat> Get()
    {
      return catRepo.GetAllCats();
    }

  }
}
