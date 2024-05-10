using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.DataAccesLayer
{
    public class MultiShopContext : DbContext
    {
        public MultiShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=CA-R214-PC13\\SQLEXPRESS;Database=106Shop;Trusted_Connection=true;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
