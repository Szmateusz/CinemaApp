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
                    
            return View(model);
        }
        [HttpGet]
        public IActionResult TicketPayment([FromForm] TicketInfoViewModel model)
        {
                      
            return View(model);
        }
        [HttpPost]
        public IActionResult Pay(TicketInfoViewModel model)
        {
            var schedule = _scheduleRepository.GetScheduleById(model.Schedule.ID);

            foreach (var res in model.Tickets)
            {
                var r = new ReservationModel
                {
                    SeanceID = schedule.ID,
                    Row = res.Row,
                    Place = res.Place,
                    ReservationDate = DateTime.Now,


                };
            }
            return RedirectToAction("Summary",);
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
