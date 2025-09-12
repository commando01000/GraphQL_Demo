using GraphQL.Types;

namespace GraphQL_Demo.Type
{
    public class MenuInputType : InputObjectGraphType
    {
        public MenuInputType()
        {
            Name = "MenuInput";
            Field<NonNullGraphType<IntGraphType>>("id").Description("The id of the menu");
            Field<NonNullGraphType<StringGraphType>>("name").Description("The name of the menu");
            Field<NonNullGraphType<FloatGraphType>>("price").Description("The price of the menu");
            Field<StringGraphType>("description").Description("The description of the menu");
            Field<NonNullGraphType<IntGraphType>>("categoryId").Description("The category id of the menu");
            Field<StringGraphType>("imageUrl").Description("The image URL of the menu");
        }
    }
}
