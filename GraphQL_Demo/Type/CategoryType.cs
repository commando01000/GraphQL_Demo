using GraphQL.Types;
using GraphQL_Demo.Entities;
using GraphQL_Demo.Repositories;

namespace GraphQL_Demo.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IMenuRepository menuRepository)
        {
            Field(x => x.Id).Description("Category Id");
            Field(x => x.Name).Description("Category Name");
            Field(x => x.Description, nullable: true).Description("Category Description");
            Field<ListGraphType<MenuType>>(
                "menus"
            ).Resolve(context => menuRepository.getMenuByCategoryId(context.Source.Id))
            .Description("Menus under this category");
        }
    }
}
