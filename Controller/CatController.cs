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
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CatController : Controller
    {

        private readonly CatContext _context;

        public CatController(CatContext CatContext)
        {
            _context = CatContext;
        }

        // GET request to get the list of all non-sold cats stored in API
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return _context.Cats.OrderBy(p => p.Name).ToList();
        }

        // GET request to get all information about specific cat (with cat id as a parameter)
        [HttpGet("{id}")]
        public Cat GetById(int id)
        {
            return _context.Cats.FirstOrDefault(t => t.ID == id);
        }

        // POST request to add new cat object
        [HttpPost]
        public IActionResult Create([FromBody] Cat cat)
        {
            if (cat == null)
            {
                return BadRequest();
            }

            _context.Cats.Add(cat);
            _context.SaveChanges();

            return new NoContentResult();
        }

        // PUT request to update cat (with cat id as a parameter and a field/fields to update)
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Cat cat)
        {
            if (cat == null || cat.ID != id)
            {
                return BadRequest();
            }

            var updatedCat = _context.Cats.FirstOrDefault(t => t.ID == id);
            if (updatedCat == null)
            {
                return NotFound();
            }
            updatedCat.ID = cat.ID;
            updatedCat.Name = cat.Name;
            updatedCat.Breed = cat.Breed;
            updatedCat.Birthdate = cat.Birthdate;
            updatedCat.Weight = cat.Weight;
            updatedCat.Color = cat.Color;
            updatedCat.Price = cat.Price;
            updatedCat.Picture = cat.Picture;

            _context.Cats.Update(updatedCat);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE request to remove the cat (with cat id as a parameter)
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var cat = _context.Cats.FirstOrDefault(t => t.ID == id);
            if (cat == null)
            {
                return NotFound();
            }

            _context.Cats.Remove(cat);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
