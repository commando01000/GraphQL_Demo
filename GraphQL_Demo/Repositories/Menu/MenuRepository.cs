using GraphQL_Demo.Data;
using GraphQL_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Demo.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly GraphQLDbContext _context;

        public MenuRepository(GraphQLDbContext graphQLDbContext)
        {
            _context = graphQLDbContext;
        }
        public Menu AddMenu(Menu menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
            return menu;
        }

        public bool DeleteMenu(int id)
        {
            var menu = _context.Menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Menu> GetAllMenu()
        {
            return _context.Menus.ToList();
        }

        public List<Menu> getMenuByCategoryId(int categoryId)
        {
            var category = _context.Categories.Include(c => c.Menus).FirstOrDefault(c => c.Id == categoryId);
            return category?.Menus ?? new List<Menu>();
        }

        public Menu GetMenuById(int id)
        {
            return _context.Menus.FirstOrDefault(m => m.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var existingMenu = _context.Menus.FirstOrDefault(m => m.Id == id);
            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                existingMenu.Description = menu.Description;
                existingMenu.Price = menu.Price;
            }
            _context.SaveChanges();
            return existingMenu;
        }
    }
}
