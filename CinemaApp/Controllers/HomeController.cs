using CinemaApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PriceList()
        {
            return View();
        }
        public IActionResult Repeitorie()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult MovieView()
        {
            return View();
        }

    }
}