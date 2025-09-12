using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(int id, Reservation reservation);
        bool DeleteReservation(int id);
    }
}
