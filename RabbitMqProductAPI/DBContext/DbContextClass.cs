using Microsoft.EntityFrameworkCore;
using RabbitMqProductAPI.Models;
using RabbitMqProductAPI.Services;

namespace RabbitMqProductAPI.DBContext
{
    public class DbContextClass:DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
        

        public DbSet<Product> Products { get; set; }
    }
}
