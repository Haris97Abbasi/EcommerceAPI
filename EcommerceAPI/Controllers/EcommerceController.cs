using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly IEcommerceService _service;

        public EcommerceController(IEcommerceService service)
        {
            _service = service;
        }

        // GET: api/Ecommerce/Products
        [HttpGet("Products")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Ok(_service.GetAllProducts());
        }

        // GET: api/Ecommerce/Product/{id}
        [HttpGet("Product/{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // GET: api/Ecommerce/SearchProducts?searchTerm={searchTerm}
        [HttpGet("SearchProducts")]
        public ActionResult<List<Product>> SearchProducts(string searchTerm)
        {
            return Ok(_service.SearchProducts(searchTerm));
        }

        // GET: api/Ecommerce/FilterByCategory/{categoryId}
        [HttpGet("FilterByCategory/{categoryId}")]
        public ActionResult<List<Product>> FilterProductsByCategory(int categoryId)
        {
            return Ok(_service.FilterProductsByCategory(categoryId));
        }

        // GET: api/Ecommerce/FilterByPriceRange?minPrice={minPrice}&maxPrice={maxPrice}
        [HttpGet("FilterByPriceRange")]
        public ActionResult<List<Product>> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return Ok(_service.FilterProductsByPriceRange(minPrice, maxPrice));
        }

        // GET: api/Ecommerce/Availability/{productId}
        [HttpGet("Availability/{productId}")]
        public ActionResult<bool> GetProductAvailability(int productId)
        {
            return Ok(_service.GetProductAvailability(productId));
        }

        // POST: api/Ecommerce/Product
        [HttpPost("Product")]
        public ActionResult AddProduct([FromBody] Product product)
        {
            if (!_service.AddProduct(product))
                return BadRequest("Failed to add product.");
            return Ok("Product added successfully.");
        }

        // PUT: api/Ecommerce/Product/{id}
        [HttpPut("Product/{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            if (!_service.UpdateProduct(id, product))
                return NotFound("Product not found or failed to update.");
            return Ok("Product updated successfully.");
        }

        // DELETE: api/Ecommerce/Product/{id}
        [HttpDelete("Product/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            if (!_service.DeleteProduct(id))
                return NotFound("Product not found or failed to delete.");
            return Ok("Product deleted successfully.");
        }

        // GET: api/Ecommerce/Categories
        [HttpGet("Categories")]
        public ActionResult<List<Category>> GetCategories()
        {
            return Ok(_service.GetCategories());
        }

        // POST: api/Ecommerce/Category
        [HttpPost("Category")]
        public ActionResult AddCategory([FromBody] Category category)
        {
            if (!_service.AddCategory(category))
                return BadRequest("Failed to add category.");
            return Ok("Category added successfully.");
        }

        // PUT: api/Ecommerce/Category/{id}
        [HttpPut("Category/{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (!_service.UpdateCategory(id, category))
                return NotFound("Category not found or failed to update.");
            return Ok("Category updated successfully.");
        }

        // DELETE: api/Ecommerce/Category/{id}
        [HttpDelete("Category/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            if (!_service.DeleteCategory(id))
                return NotFound("Category not found or failed to delete.");
            return Ok("Category deleted successfully.");
        }
    }
}
