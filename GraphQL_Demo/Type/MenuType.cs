using GraphQL.Types;
using GraphQL_Demo.DTOs;

namespace GraphQL_Demo.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType()
        {
            Field(x => x.Id).Description("Menu Id");
            Field(x => x.Name).Description("Menu Name");
            Field(x => x.Description, nullable: true).Description("Menu Description");
            Field(x => x.Price).Description("Menu Price");
        }
    }
}
