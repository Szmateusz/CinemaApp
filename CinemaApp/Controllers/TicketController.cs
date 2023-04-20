using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TicketInfo()
        {
            return View();
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
