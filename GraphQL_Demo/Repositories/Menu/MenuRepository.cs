using GraphQL_Demo.DTOs;

namespace GraphQL_Demo.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private static List<Menu> Menus = new List<Menu>()
        {
            new Menu() { Id = 1, Name = "Pizza", Description = "Delicious cheese pizza", Price = 9.99 },
            new Menu() { Id = 2, Name = "Burger", Description = "Juicy beef burger", Price = 7.99 },
            new Menu() { Id = 3, Name = "Pasta", Description = "Italian pasta with marinara sauce", Price = 8.99 },
            new Menu() { Id = 4, Name = "Salad", Description = "Fresh garden salad", Price = 5.99 },
            new Menu() { Id = 5, Name = "Sushi", Description = "Assorted sushi platter", Price = 12.99 }
        };
        public Menu AddMenu(Menu menu)
        {
            Menus.Add(menu);
            return menu;
        }

        public bool DeleteMenu(int id)
        {
            var menu = Menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                Menus.Remove(menu);
                return true;
            }
            return false;
        }

        public List<Menu> GetAllMenu()
        {
            return Menus;
        }

        public Menu GetMenuById(int id)
        {
            return Menus.FirstOrDefault(m => m.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var existingMenu = Menus.FirstOrDefault(m => m.Id == id);
            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                existingMenu.Description = menu.Description;
                existingMenu.Price = menu.Price;
            }
            return existingMenu;
        }
    }
}
