# E-commerce API Project

This project is a RESTful API built with ASP.NET Core for managing an e-commerce product catalog. It provides functionality to manage products and categories, including features like filtering by category and price, and searching for products by name or description.

## Features

- **Product Management**: Add, update, delete, and retrieve products.
- **Category Management**: Add, update, delete, and retrieve product categories.
- **Filtering & Searching**:
  - Filter products by category.
  - Filter products by price range.
  - Search products by name or description.
- **Product Availability Check**: Check if a product is available based on stock.

## Technology Stack

- **Framework**: ASP.NET Core Web API
- **Database**: Entity Framework Core with a relational database (e.g., SQL Server)
- **Language**: C#
- **IDE**: Visual Studio 2022

## Getting Started

### Prerequisites

- .NET SDK 6.0 or later
- A SQL Server instance (or any other relational database)
- Visual Studio 2022 (recommended for ease of setup)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/ecommerce-api.git
   cd ecommerce-api

2. Set up the database connection in `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Your_Database_Connection_String_Here"
     }
   }

3. Run database migrations to set up the database schema:
   ```bash
   dotnet ef database update

4. Start the API:
   ```bash
   dotnet run


The API will run on `https://localhost:5001` by default.

## API Endpoints

### Products
- **Get All Products**  
  `GET /api/Ecommerce/Products`
- **Get Product by ID**  
  `GET /api/Ecommerce/Product/{id}`
- **Add Product**  
  `POST /api/Ecommerce/Product`
- **Update Product**  
  `PUT /api/Ecommerce/Product/{id}`
- **Delete Product**  
  `DELETE /api/Ecommerce/Product/{id}`
- **Filter Products by Category**  
  `GET /api/Ecommerce/FilterByCategory/{categoryId}`
- **Filter Products by Price Range**  
  `GET /api/Ecommerce/FilterByPriceRange?minPrice={minPrice}&maxPrice={maxPrice}`
- **Search Products**  
  `GET /api/Ecommerce/SearchProducts?searchTerm={searchTerm}`
- **Check Product Availability**  
  `GET /api/Ecommerce/Availability/{productId}`

### Categories
- **Get All Categories**  
  `GET /api/Ecommerce/Categories`
- **Add Category**  
  `POST /api/Ecommerce/Category`
- **Update Category**  
  `PUT /api/Ecommerce/Category/{id}`
- **Delete Category**  
  `DELETE /api/Ecommerce/Category/{id}`



## Example Requests


### Add a Product

```bash
curl -X POST "https://localhost:5001/api/Ecommerce/Product" \
-H "Content-Type: application/json" \
-d '{
      "name": "Laptop",
      "description": "Dell Latitude E5450",
      "price": 300,
      "stockQuantity": 10,
      "categoryId": 1,
      "isAvailable": true
    }'
```

## Filter Products by Price Range

```bash
curl -X GET "https://localhost:5001/api/Ecommerce/FilterByPriceRange?minPrice=100&maxPrice=500"
```


## Future Enhancements

**Authentication & Authorization**: Implement JWT-based authentication.
**Pagination**: Add pagination for large result sets.
**Error Logging**: Improve error handling and logging for debugging.
**Unit Tests**: Add unit tests for service and controller logic.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
