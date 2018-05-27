using Microsoft.EntityFrameworkCore;

namespace via_web_application {

  public class CatContext : DbContext {
    public CatContext(DbContextOptions<CatContext> options) : base (options) {
    }

    // Tables
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

  }
}