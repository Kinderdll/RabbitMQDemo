using Microsoft.EntityFrameworkCore;
using RabbitMqProductAPI.DBContext;
using RabbitMqProductAPI.Models;

namespace RabbitMqProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContextClass;

        public ProductService(DbContextClass dbContextClass)
        {
            _dbContextClass = dbContextClass;
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContextClass.Products.Add(product);
            _dbContextClass.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContextClass.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var result = _dbContextClass.Remove(product);
            _dbContextClass.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return _dbContextClass.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return _dbContextClass.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContextClass.Products.Update(product);
            _dbContextClass.SaveChanges();
            return result.Entity;
        }
    }
}
