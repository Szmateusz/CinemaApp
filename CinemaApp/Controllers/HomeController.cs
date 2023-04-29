using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CinemaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMoviesRepository _moviesRepository;
        public HomeController(ILogger<HomeController> logger,IMoviesRepository moviesRepository)
        {

            _logger = logger;
            _moviesRepository = moviesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pricing()
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

        public IActionResult MovieDetail(int id)
        {
            var movie = _moviesRepository.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult PurchaseTicket(int id)
        {
            return RedirectToAction("Index","Ticket",id);
        }

    }
}