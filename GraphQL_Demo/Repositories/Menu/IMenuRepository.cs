using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Repositories
{
    public interface IMenuRepository
    {
        List<Menu> GetAllMenu();
        Menu GetMenuById(int id);
        Menu AddMenu(Menu menu);
        Menu UpdateMenu(int id, Menu menu);
        bool DeleteMenu(int id);
        List<Menu> getMenuByCategoryId(int categoryId);

    }
}
