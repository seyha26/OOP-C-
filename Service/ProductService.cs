using WebStockManagement.Dto.Request;
using WebStockManagement.Entities;

namespace WebStockManagement.Service;

public interface ProductService
{
    List<Product> GetAllProducts(Category category);
    Product GetProductById(int id);
    void CreateProduct(ProductRequest req);
    void UpdateProduct(ProductRequest req);
    void DeleteProduct(ProductRequest req);
}