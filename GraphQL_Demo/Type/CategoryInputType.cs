using GraphQL.Types;

namespace GraphQL_Demo.Type
{
    public class CategoryInputType : InputObjectGraphType
    {
        public CategoryInputType()
        {
            Name = "CategoryInput";
            Field<NonNullGraphType<IntGraphType>>("id").Description("The id of the category");
            Field<NonNullGraphType<StringGraphType>>("name").Description("The name of the category");
            Field<StringGraphType>("description").Description("The description of the category");
            Field<ListGraphType<MenuInputType>>("menus").Description("The menus of the category");
        }
    }
}
