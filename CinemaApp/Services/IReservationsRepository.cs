using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Services
{
    public interface IReservationsRepository
    {
        ReservationModel GetReservationById(int id);
        IEnumerable<ReservationModel> GetAllReservations();
        IEnumerable<ReservationModel> GetReservationsForMovie(int id);
        IEnumerable<ReservationModel> GetReservationsForSchedule(int id);
        IEnumerable<ReservationModel> GetReservationsForHall(int id);
        void AddReservation(ReservationModel reservation);
        void UpdateReservarion(ReservationModel reservation);
        void DeleteReservation(int id);
    }
}
