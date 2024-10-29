using EcommerceAPI.Models;
using System.Collections.Generic;

namespace EcommerceAPI.Services
{
    public interface IEcommerceService
    {
        // Product-related methods
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        List<Product> SearchProducts(string searchTerm);
        List<Product> FilterProductsByCategory(int categoryId);
        List<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice);
        bool GetProductAvailability(int productId);
        bool AddProduct(Product product);
        bool UpdateProduct(int productId, Product product);
        bool DeleteProduct(int productId);

        // Category-related methods
        List<Category> GetCategories();
        bool AddCategory(Category category);
        bool UpdateCategory(int categoryId, Category category);
        bool DeleteCategory(int categoryId);
    }
}
