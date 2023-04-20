using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
