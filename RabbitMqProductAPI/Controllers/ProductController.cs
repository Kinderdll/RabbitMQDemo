using Microsoft.AspNetCore.Mvc;
using RabbitMqProductAPI.Models;
using RabbitMqProductAPI.RabbitMQ;
using RabbitMqProductAPI.Services;

namespace RabbitMqProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public ProductController(IProductService productService, IRabbitMQProducer rabbitMQProducer)
        {
            _productService = productService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet("productlst")]
        public IEnumerable<Product> ProductList()
        {
            return _productService.GetProductList();
        }

        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return _productService.GetProductById(Id);
        }

        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = _productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabbitMQProducer.SendProductMessage(productData);
            return productData;
        }
        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }
    }
}
