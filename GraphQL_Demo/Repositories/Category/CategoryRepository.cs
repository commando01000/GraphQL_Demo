
using GraphQL_Demo.Data;
using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GraphQLDbContext _dbContext;
        public CategoryRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Category AddCategory(Category category)
        {
            var newCategory = _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return newCategory.Entity;
        }

        public bool DeleteCategory(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return false;
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public Category UpdateCategory(int id, Category category)
        {
            var existingCategory = _dbContext.Categories.Find(id);
            if (existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.Menus = category.Menus;
            _dbContext.SaveChanges();
            return existingCategory;
        }
    }
}
