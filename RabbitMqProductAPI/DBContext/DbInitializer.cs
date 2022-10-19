using Microsoft.EntityFrameworkCore;
using RabbitMqProductAPI.Models;
using RabbitMqProductAPI.Services;

namespace RabbitMqProductAPI.DBContext
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductDescription = "Mobile",
                    ProductName = "Apple 14 Pro",
                    ProductPrice = 1400,
                    ProductStock = 20
                },
                  new Product
                  {
                      ProductId = 2,
                      ProductDescription = "Mobile",
                      ProductName = "Apple 14 Plus",
                      ProductPrice = 1200,
                      ProductStock = 20
                  }
                );
        }


    };
}
