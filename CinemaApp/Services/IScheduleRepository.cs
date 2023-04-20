using CinemaApp.Models;
using System;
using System.Collections.Generic;

namespace CinemaApp.Services
{
    public interface IScheduleRepository
    {
        ScheduleModel GetScheduleById(int id);
        IEnumerable<ScheduleModel> GetAllSchedules();
        IEnumerable<ScheduleModel> GetScheduleByDate(DateTime date);
        void AddSchedule(ScheduleModel schedule);
        void UpdateSchedule(ScheduleModel schedule);
        void DeleteSchedule(int id);
    }
}
