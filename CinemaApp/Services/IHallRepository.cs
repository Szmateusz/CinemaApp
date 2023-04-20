using CinemaApp.Models;
using System.Collections.Generic;

namespace CinemaApp.Services
{
    public interface IHallRepository
    {
        HallModel GetHallById(int id);
        IEnumerable<HallModel> GetAllHalls();
        void AddHall(HallModel hall);
        void UpdateHall(HallModel hall);
        void DeleteHall(int id);
    }
}
