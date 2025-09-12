using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Entities;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Mutation
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuRepository menuRepository)
        {
            Field<MenuType>("AddMenuItem")
                .Argument<NonNullGraphType<MenuInputType>>("menu")
                .Resolve(ctx =>
                {
                    var menu = ctx.GetArgument<Menu>("menu");
                    return menuRepository.AddMenu(menu);
                });

            Field<MenuType>("UpdateMenuItem")
                .Argument<NonNullGraphType<MenuInputType>>("menu")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    var menu = ctx.GetArgument<Menu>("menu");
                    return menuRepository.UpdateMenu(id, menu);
                });

            Field<MenuType>("DeleteMenuItem")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return menuRepository.DeleteMenu(id);
                });
        }
    }
}
