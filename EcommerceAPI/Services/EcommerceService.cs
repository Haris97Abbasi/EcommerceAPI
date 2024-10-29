using EcommerceAPI.Data;
using EcommerceAPI.Models;

namespace EcommerceAPI.Services
{
    public class EcommerceService : IEcommerceService
    {
        private readonly ApplicationDbContext _db;
        public EcommerceService(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool AddCategory(Category category)
        {
            if (category == null)
            {
                return false;
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            return true;
        }

        public bool AddProduct(Product product)
        {
           if(product == null)
            {
                return false;
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return false;
            }
            var category = _db.Categories.Find(categoryId);
            if (category == null) {
                return false;
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                return false;
            }
            var product = _db.Products.Find(productId);
            if (product == null)
            {
                return false;
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return true;
        }

        public List<Product> FilterProductsByCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return null;
            }
            var productList = _db.Products.Where(p => p.CategoryId == categoryId).ToList();
            return productList;
        }

        public List<Product> FilterProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
           if(minPrice <= 0 || maxPrice <= 0)
            {
                return null;
            }
            var productList = _db.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
            return productList;
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public bool GetProductAvailability(int productId)
        {
            if(productId <= 0)
            {
                return false;
            }
            var product = _db.Products.Find(productId);
            if (product == null)
            {
                return false;
            }
            return product.IsAvailable;
        }

        public Product GetProductById(int productId)
        {
            if (productId <= 0)
            {
                return null;
            }
            var product = _db.Products.Find(productId);
            return product;
        }

        public List<Product> SearchProducts(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return null;
            }
            var productList = _db.Products.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm)).ToList();
            return productList;
        }

        public bool UpdateCategory(int categoryId, Category category)
        {
            if (categoryId <= 0 || category == null)
            {
                return false;
            }
            var existingCategory = _db.Categories.Find(categoryId);
            if (existingCategory == null)
            {
                return false;
            }
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            _db.SaveChanges();
            return true;
        }

        public bool UpdateProduct(int productId, Product product)
        {
            if (productId <= 0 || product == null)
            {
                return false;
            }
            var existingProduct = _db.Products.Find(productId);
            if (existingProduct == null)
            {
                return false;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.StockQuantity = product.StockQuantity;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.IsAvailable = product.IsAvailable;
            _db.SaveChanges();
            return true;
        }
    }
}
