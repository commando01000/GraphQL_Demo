using GraphQL.Types;

namespace GraphQL_Demo.Type
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Name = "ReservationInput";
            Field<NonNullGraphType<StringGraphType>>("customerName").Description("the name of the customer making the reservation");
            Field<NonNullGraphType<StringGraphType>>("contactInfo").Description("the contact info of the customer");
            Field<NonNullGraphType<DateTimeGraphType>>("reservationDate").Description("the date and time of the reservation");
            Field<NonNullGraphType<IntGraphType>>("numberOfGuests").Description("the number of guests for the reservation");
            Field<StringGraphType>("specialRequests").Description("any special requests for the reservation");
        }
    }
}
