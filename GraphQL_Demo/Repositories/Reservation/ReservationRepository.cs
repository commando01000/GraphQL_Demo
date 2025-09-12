using GraphQL_Demo.Data;
using GraphQL_Demo.Entities;

namespace GraphQL_Demo.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly GraphQLDbContext _dbContext;
        public ReservationRepository(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Reservation AddReservation(Reservation reservation)
        {
            var newReservation = _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();
            return newReservation.Entity;
        }

        public bool DeleteReservation(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            if (reservation == null)
            {
                return false;
            }
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Reservation> GetAllReservations()
        {
            var reservations = _dbContext.Reservations.ToList();
            return reservations;
        }

        public Reservation GetReservationById(int id)
        {
            var reservation = _dbContext.Reservations.Find(id);
            return reservation;
        }

        public Reservation UpdateReservation(int id, Reservation reservation)
        {
            var existingReservation = _dbContext.Reservations.Find(id);
            if (existingReservation == null)
            {
                return null;
            }
            existingReservation.CustomerName = reservation.CustomerName;
            existingReservation.NumberOfGuests = reservation.NumberOfGuests;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.ContactInfo = reservation.ContactInfo;
            existingReservation.SpecialRequests = reservation.SpecialRequests;
            _dbContext.SaveChanges();
            return existingReservation;
        }
    }
}
