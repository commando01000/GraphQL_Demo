using GraphQL.Types;

namespace GraphQL_Demo.Mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<ReservationMutation>("reservation").Resolve(_ => new { });
            Field<CategoryMutation>("category").Resolve(_ => new { });
            Field<MenuMutation>("menu").Resolve(_ => new { });
        }
    }
}
