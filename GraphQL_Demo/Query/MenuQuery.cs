using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Repositories;

namespace GraphQL_Demo.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<Type.MenuType>>(
                "Menus",
                resolve: context => menuRepository.GetAllMenu()
            );

            Field<Type.MenuType>(
                "Menu",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "Id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("Id");
                    return menuRepository.GetMenuById(id);
                }
            );
        }
    }
}
