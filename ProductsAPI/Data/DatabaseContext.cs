using ProductsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAPI.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Product> Products { get; set; }        
    }
}
