using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Query
{
    public class CategoryQuery : ObjectGraphType
    {
        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            Field<ListGraphType<CategoryType>>("categories")
            .Resolve(ctx => categoryRepository.GetAllCategories());

            Field<CategoryType>("category")
                .Argument<NonNullGraphType<IntGraphType>>("id", "The category id")  // new style
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id"); // keep using GetArgument
                    return categoryRepository.GetCategoryById(id);
                });
        }
    }
}
