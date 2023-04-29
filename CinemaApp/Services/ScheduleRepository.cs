using CinemaApp.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services
{
    public class ScheduleRepository : IScheduleRepository
    {
        public readonly DBContext _context;
        public ScheduleRepository(DBContext context) {
            _context = context;
        }
        public ScheduleModel GetScheduleById(int id)
        {
            return _context.Schedules.Include(m => m.Movie).Include(h => h.Hall).Include(r => r.Reservations).SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<ScheduleModel> GetAllSchedules()

        {
            return _context.Schedules.Include(m=>m.Movie).Include(h=>h.Hall).Include(r=>r.Reservations).ToList();
        }
        public IEnumerable<ScheduleModel> GetScheduleByDate(DateTime date) {

            return _context.Schedules.Include(m => m.Movie).Include(h => h.Hall).Include(r => r.Reservations).Where(s=>s.Date.Equals(date)).ToList();
        }

        public void AddSchedule(ScheduleModel schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }
        public void UpdateSchedule(ScheduleModel schedule)
        {
            _context.Schedules.Update(schedule);
            _context.SaveChanges();
        }
        public void DeleteSchedule(int id)
        {
            var schedule = GetScheduleById(id);
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
        }
    }
}
