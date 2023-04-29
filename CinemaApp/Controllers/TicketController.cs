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
        public IActionResult TicketInfo([FromBody] List<TicketModel> tickets)
        {
            var model = tickets;

            return View(model);
        }
        public IActionResult CustomerData()
        {
            return View();
        }
        public IActionResult TicketBuy()
        {
            return View();
        }
        public IActionResult Summary()
        {
            return View();
        }
    }
}
