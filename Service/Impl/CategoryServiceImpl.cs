using WebStockManagement.Context;
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
        category.Status = Constants.Constants.StatusActive;
        _context.Category.Add(category);
        _context.SaveChanges();
    }

    public List<Category> GetCategoriesAll()
    {
        var categoryList = _context.Category
            .Where(c=>c.Status == Constants.Constants.StatusActive)
            .ToList();
        return categoryList;
    }

    public Category GetCategoryById(int Id)
    {
        var category = _context.Category
            .SingleOrDefault(c => c.Id == Id && c.Status == Constants.Constants.StatusActive);
        if (category == null)
        {
            throw new WebException("400", "Category not found");
        }
        return category;
    }

    public void UpdateCategroy(Category category)
    {
        var existingCategory = _context.Category
            .FirstOrDefault(c => c.Id == category.Id && c.Status == Constants.Constants.StatusActive);
        if (existingCategory == null)
        {
            throw new WebException("400", "Category not found");
        }

        existingCategory.Name = category.Name;
        _context.Update(existingCategory);
        _context.SaveChanges();
    }

    public void DeleteCategory(Category category)
    {
        var existingCategory = _context.Category
            .FirstOrDefault(c => c.Id == category.Id && c.Status == Constants.Constants.StatusActive);
        if (existingCategory == null)
        {
            throw new WebException("400", "Category not found");
        }
        existingCategory.Status = Constants.Constants.StatusDelete;
        _context.Update(existingCategory);
        _context.SaveChanges();
    }

}