using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuRepository menuRepository)
        {
            Field<ListGraphType<MenuType>>("menus")
            .Resolve(ctx => menuRepository.GetAllMenu());

            Field<MenuType>("menu")
                .Argument<NonNullGraphType<IntGraphType>>("id", "The menu id")  // new style
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");   // keep using GetArgument
                    return menuRepository.GetMenuById(id);
                });

        }
    }
}
