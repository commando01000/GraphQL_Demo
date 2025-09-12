using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationRepository reservationRepository)
        {
            Field<ListGraphType<ReservationType>>("reservations")
            .Resolve(ctx => reservationRepository.GetAllReservations());

            Field<ReservationType>("reservation")
                .Argument<NonNullGraphType<IntGraphType>>("id", "The reservation id")  // new style
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id"); // keep using GetArgument
                    return reservationRepository.GetReservationById(id);
                });
        }
    }
}
