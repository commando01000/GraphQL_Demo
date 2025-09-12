namespace GraphQL_Demo.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string SpecialRequests { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
    }
}
