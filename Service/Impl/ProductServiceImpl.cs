using WebStockManagement.Context;
using WebStockManagement.Dto.Request;
using WebStockManagement.Entities;
using WebStockManagement.Exceptions;

namespace WebStockManagement.Service.Impl;

public class ProductServiceImpl : ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductServiceImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    public void CreateProduct(ProductRequest req)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(ProductRequest req)
    {
        throw new NotImplementedException();
    }

    public List<Product> GetAllProducts(Category category)
    {
        List<Product> productList = _context
            .Products.ToList().OrderByDescending(c => c.Id).ToList();
        return productList;
    }

    public Product GetProductById(int id)
    {
        var product = _context.Products
            .FirstOrDefault(c => c.Id == id);
        if (product == null)
        {
            throw new WebException("400", "Category not found");
        }
        return product;
    }

    public void UpdateProduct(ProductRequest req)
    {
        throw new NotImplementedException();
    }
}