using WebStockManagement.Context;
using WebStockManagement.Entities;
using WebStockManagement.Exceptions;

namespace WebStockManagement.Service.Impl;

public class CategoryServiceImpl : CategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryServiceImpl(ApplicationDbContext context)
    {
        _context = context;
    }

    public void CreateCategory(Category category)
    {
        var checkCategory = _context.Category.SingleOrDefault(c => c.Code == category.Code);
        if (checkCategory != null)
        {
            throw new WebException("400", "Categroy code already exists");
        }
        _context.Category.Add(category);
        _context.SaveChanges();
    }

    public List<Category> GetCategoriesAll()
    {
        var categoryList = _context.Category.ToList();
        return categoryList;
    }

    public Category GetCategoryById(int Id)
    {
        var category = _context.Category.Where(c => c.Id == Id).SingleOrDefault();
        if (category == null)
        {
            throw new WebException("400", "Category not found");
        }
        return category;
    }

    public void UpdateCategroy(Category category)
    {
        var existingCategory = _context.Category.FirstOrDefault(c => c.Id == category.Id);
        if (existingCategory == null)
        {
            throw new WebException("400", "Category not found");
        }

        _context.Entry(existingCategory).CurrentValues.SetValues(category);
        _context.SaveChanges();
    }

    public void DeleteCategory(Category category)
    {
        var existingCategory = _context.Category.Where(c => c.Id == category.Id).FirstOrDefault();
        if (existingCategory == null)
        {
            throw new WebException("400", "Category not found");
        }
        _context.Category.Remove(existingCategory);
        _context.SaveChanges();
    }

}