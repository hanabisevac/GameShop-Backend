using GameShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace GameShop.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Entities.Console> Consoles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameConsole> GameConsoles { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
