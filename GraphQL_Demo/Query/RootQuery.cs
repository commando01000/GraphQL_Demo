using GraphQL.Types;
namespace GraphQL_Demo.Query
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery").Resolve(_ => new { });
            Field<CategoryQuery>("categoryQuery").Resolve(_ => new { });
            Field<ReservationQuery>("reservationQuery").Resolve(_ => new { });
        }
    }
}
