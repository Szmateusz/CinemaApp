using CinemaApp.Models;
using System.Collections;

namespace CinemaApp.Services
{
    public class ReservationsRepository : IReservationsRepository
    {
        public readonly DBContext _context;
        public ReservationsRepository(DBContext context)
        {
            _context = context;
        }
        public ReservationModel GetReservationById(int id)
        {
            return _context.Reservations.SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<ReservationModel> GetAllReservations()

        {
            return _context.Reservations.ToList();
        }
        public IEnumerable<ReservationModel> GetReservationsForMovie(int id)
        {

            return _context.Reservations.Where(c => c.Seance.MovieID.Equals(id)).ToList();
        }
        public IEnumerable<ReservationModel> GetReservationsForSchedule(int id)
        {

            return _context.Reservations.Where(c => c.SeanceID.Equals(id)).ToList();
        }
        public IEnumerable<ReservationModel> GetReservationsForHall(int id)
        {

            return _context.Reservations.Where(c => c.Seance.HallID.Equals(id)).ToList();
        }
        public void AddReservation(ReservationModel reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public void UpdateReservarion(ReservationModel reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }
        public void DeleteReservation(int id)
        {
            var reservation = GetReservationById(id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
