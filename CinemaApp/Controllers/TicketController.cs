using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class TicketController : Controller
    {
        public readonly IScheduleRepository _scheduleRepository;
        public TicketController(IScheduleRepository scheduleRepository) {

            _scheduleRepository = scheduleRepository;

        }
        public IActionResult Index(int id)
        {
            var model = _scheduleRepository.GetScheduleById(id);

            return View(model);
        }
        [HttpPost]
        public IActionResult TicketInfo([FromRoute] int id ,[FromBody] List<TicketModel> tickets)
        {
            
            var schedule = _scheduleRepository.GetScheduleById(id);

            var model = new TicketInfoViewModel
            {
                Tickets = tickets,
                Schedule = schedule
            };
           
            return View(model);
        }
        public IActionResult CustomerData([FromForm] TicketInfoViewModel model)
        {
            int id = model.Schedule.ID;
            var schedule = _scheduleRepository.GetScheduleById(id);

            model.Schedule = schedule;
            var res = new ReservationModel
            {
                SeanceID = schedule.ID,
                Seance = schedule,

            };
            return View();
        }
        public IActionResult TicketPay([FromForm] TicketInfoViewModel model)
        {
            int id = model.Schedule.ID;
            var schedule = _scheduleRepository.GetScheduleById(id);

            model.Schedule = schedule;
            
            return View(model);
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
