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

    public void Add(User user) {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void Update(int id, User user)
    {
      if (user == null || user.ID != id)
      {
          return;
      }

      var dbUser = _context.Users.Find(id);
      if (dbUser == null)
      {
          return;
      }

      dbUser.Name = user.Name;
      dbUser.Address = user.Address;
      dbUser.City = user.City;
      dbUser.Country = user.Country;
      dbUser.Email = user.Email;
      dbUser.Phone = user.Phone;
      dbUser.Password = user.Password;
      dbUser.Type = user.Type;

      _context.Users.Update(user);
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
      dbOrder.User = order.User;
      dbOrder.Status = order.Status;
      dbOrder.Items = order.Items;

      _context.Orders.Update(order);
      _context.SaveChanges();
    }
  }
}