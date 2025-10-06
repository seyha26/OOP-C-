using Microsoft.EntityFrameworkCore;
using WebStockManagement.Context;
using WebStockManagement.Dto.Request;
using WebStockManagement.Entities;
using WebStockManagement.Exceptions;

namespace WebStockManagement.Service.Impl;

public class ProductServiceImpl : ProductService
{
    private readonly ApplicationDbContext _context;
    private readonly CategoryService _categoryService;

    public ProductServiceImpl(ApplicationDbContext context, CategoryService categoryService)
    {
        _context = context;
        _categoryService = categoryService;
    }

    public void CreateProduct(ProductRequest req)
    {
        var category = _categoryService.GetCategoryById(req.CategoryId);
        if(req.Name == null)
        {
            throw new WebException("400", "Product name is required");
        }
        var createProduct = new Product();
        createProduct.Name = req.Name;
        createProduct.Category = category;
        createProduct.Status = Constants.Constants.StatusActive;
        createProduct.Description = req.Description;
        _context.Products.Add(createProduct);
        _context.SaveChanges();
    }

    public void DeleteProduct(int Id)
    {
        var product = _context.Products.FirstOrDefault(c => c.Id == Id);
        product.Status = Constants.Constants.StatusDelete;
        _context.Update(product);
        _context.SaveChanges();
    }

    public List<Product> GetAllProducts()
    {
        List<Product> productList = _context.Products
            .Include(p => p.Category) .Where(c=>c.Status == Constants.Constants.StatusActive).ToList().OrderByDescending(c => c.Id).ToList();
        return productList;
    }

    public Product GetProductById(int Id)
    {
        var product = _context.Products
            .Include(p => p.Category) 
            .SingleOrDefault(p => p.Id == Id && p.Status == Constants.Constants.StatusActive);
        if (product == null)
        {
            throw new WebException("400", "Category not found");
        }
        return product;
    }

    public void UpdateProduct(ProductRequest req)
    {
        var category = _categoryService.GetCategoryById(req.CategoryId);
        var product = GetProductById(req.Id);
        if(product == null)
        {
            throw new WebException("400", "Product not found");
        }
        product.Name = req.Name;
        product.Category = category;
        product.Description = req.Description;
        _context.Update(product);
        _context.SaveChanges();
    }
}