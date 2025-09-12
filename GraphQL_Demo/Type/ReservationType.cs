using GraphQL.Types;
using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Type
{
    public class ReservationType : ObjectGraphType<Reservation>
    {
        public ReservationType()
        {
            Field(x => x.Id).Description("Reservation Id");
            Field(x => x.CustomerName).Description("Customer Name");
            Field(x => x.NumberOfGuests).Description("Number of Guests");
            Field(x => x.ReservationDate).Description("Reservation Date");
            Field(x => x.ContactInfo).Description("Contact Information");
            Field(x => x.SpecialRequests, nullable: true).Description("Special Requests");
        }
    }

}
