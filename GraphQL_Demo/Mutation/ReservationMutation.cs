using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.Entities;
using GraphQL_Demo.Repositories;
using GraphQL_Demo.Type;

namespace GraphQL_Demo.Mutation
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservationRepository reservationRepository)
        {
            Field<ReservationType>("AddReservation")
                .Argument<NonNullGraphType<ReservationInputType>>("reservation")
                .Resolve(ctx =>
                {
                    var reservation = ctx.GetArgument<Reservation>("reservation");
                    return reservationRepository.AddReservation(reservation);
                });
            Field<ReservationType>("UpdateReservation")
                .Argument<NonNullGraphType<ReservationInputType>>("reservation")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    var reservation = ctx.GetArgument<Reservation>("reservation");
                    return reservationRepository.UpdateReservation(id, reservation);
                });
            Field<ReservationType>("DeleteReservation")
                .Argument<NonNullGraphType<IntGraphType>>("id")
                .Resolve(ctx =>
                {
                    var id = ctx.GetArgument<int>("id");
                    return reservationRepository.DeleteReservation(id);
                });
        }
    }
}
