namespace WebStockManagement.Service;

public interface CategoryService
{
    List<Category> GetCategoriesAll();
    Category GetCategoryById(int Id);
    void CreateCategory(Category category);
    void UpdateCategroy(Category category);
    void DeleteCategory(Category category);
}
