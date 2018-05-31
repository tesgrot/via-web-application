using System.Collections.Generic;
using System.Linq;


namespace via_web_application {
  public class CatRepository {
    private readonly CatContext _context;

    public CatRepository(CatContext context) {
      _context = context;
    }

    public IEnumerable<Cat> GetAllCats() {
      return _context.Cats.OrderBy(p => p.Name).ToList();
    }

    public Cat GetCat(int id) {
      return _context.Cats.FirstOrDefault(t => t.ID == id);
    }

    public void Add(Cat cat) {
      _context.Cats.Add(cat);
      _context.SaveChanges();
    }

    public void Remove(int id)
    {
      _context.Cats.Remove(_context.Cats.Where(t => t.ID == id).SingleOrDefault());
      _context.SaveChanges();
    }

    public void Add(Order order) {
      _context.Orders.Add(order);
      _context.SaveChanges();
    }

    public void Update(int id, Order order)
    {
      if (order == null || order.ID != id)
      {
          return;
      }

      var dbOrder = _context.Orders.Find(id);
      if (dbOrder == null)
      {
          return;
      }

      dbOrder.Date = order.Date;
      dbOrder.Status = order.Status;
      dbOrder.Items = order.Items;

      _context.Orders.Update(order);
      _context.SaveChanges();
    }
  }
}