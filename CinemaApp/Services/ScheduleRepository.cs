using CinemaApp.Models;
using System.Collections;

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
            return _context.Schedules.SingleOrDefault(m => m.ID == id);
        }
        public IEnumerable<ScheduleModel> GetAllSchedules()

        {
            return _context.Schedules.ToList();
        }
        public IEnumerable<ScheduleModel> GetScheduleByDate(DateTime date) {

            return _context.Schedules.Where(s=>s.Date.Equals(date)).ToList();
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
