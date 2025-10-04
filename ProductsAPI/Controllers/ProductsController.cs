using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers 
{
    // localhost:5000/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {

        private static List<Product>? _products;

        public ProductsController()
        {
            _products = new List<Product> {
                new() {ProductId = 1, ProductName = "Iphone", Price = 60000, IsActive=true},
                new() {ProductId = 2, ProductName = "Xiaomi", Price = 50000, IsActive=true},
                new() {ProductId = 3, ProductName = "Samsung", Price = 40000, IsActive=true},
                new() {ProductId = 4, ProductName = "Huawei", Price = 30000, IsActive=true}
            };
        }


        // localhost:5000/api/products => GET
        [HttpGet]
        public IActionResult GetProducts() {
           // return _products ?? new List<Product>();  _products == null ? new List<Product>() : _products;

            if(_products == null) {
                return NotFound();
            }

           return Ok(_products);
        }

        // localhost:5000/api/products/1 => GET
        [HttpGet("{id}")]
        public IActionResult GetProduct(int? id) {

            if(id == null) {

                return NotFound(); // return StatusCode(404, "...mesaj");

            }
            
            var p = _products?.FirstOrDefault(i => i.ProductId == id);

            if(p == null) {
                return NotFound();
            }

            return Ok(p);
        }
    }
}