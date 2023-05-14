using CinemaApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CinemaApp.Services
{
    public class HallRepository : IHallRepository
    {
        public readonly DBContext _context;
        public HallRepository(DBContext context) {
            _context = context;
        }
        public HallModel GetHallById(int id)
        {
            return _context.Halls.SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<HallModel> GetAllHalls()

        {
            return _context.Halls.Include(s=>s.Schedules).ToList();
        }
        public void AddHall(HallModel hall)
        {
            _context.Halls.Add(hall);
            _context.SaveChanges();
        }
        public void UpdateHall(HallModel hall)
        {
            _context.Halls.Update(hall);
            _context.SaveChanges();
        }
        public void DeleteHall(int id)
        {
            var hall = GetHallById(id);
            _context.Halls.Remove(hall);
            _context.SaveChanges();
        }

    }
}
