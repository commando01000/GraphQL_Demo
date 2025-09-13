using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category AddCategory(Category category);
        Category UpdateCategory(int id, Category category);
        bool DeleteCategory(int id);
        Category AddMenuToCategory(int categoryId, int menuId);
    }
}
