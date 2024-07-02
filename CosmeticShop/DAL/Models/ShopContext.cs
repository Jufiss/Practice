using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CosmeticShop.DAL.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;
        public ShopContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        //public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        //{ }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartProducts> CartProducts { get; set; }
        public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Firm> Firm { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

    }
}
