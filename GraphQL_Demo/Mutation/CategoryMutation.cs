using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Entities;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Mutation
{
    public class CategoryMutation : ObjectGraphType
    {
        public CategoryMutation(ICategoryRepository categoryRepository)
        {
            Field<CategoryType>("AddCategory")
                .Argument<NonNullGraphType<CategoryInputType>>("category")
                .Resolve(ctx =>
                {
                    var category = ctx.GetArgument<Category>("category");
                    return categoryRepository.AddCategory(category);
                });

            Field<CategoryType>("UpdateCategory")
                .Argument<NonNullGraphType<CategoryInputType>>("category")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    var category = ctx.GetArgument<Category>("category");
                    return categoryRepository.UpdateCategory(id, category);
                });

            Field<CategoryType>("DeleteCategory")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return categoryRepository.DeleteCategory(id);
                });

            Field<CategoryType>("AddMenuToCategory")
                .Argument<NonNullGraphType<IntGraphType>>("categoryId")
                .Argument<NonNullGraphType<IntGraphType>>("menuId")
                .Resolve(ctx =>
                {
                    var categoryId = ctx.GetArgument<int>("categoryId");
                    var menuId = ctx.GetArgument<int>("menuId");
                    return categoryRepository.AddMenuToCategory(categoryId, menuId);
                });
        }
    }
}
