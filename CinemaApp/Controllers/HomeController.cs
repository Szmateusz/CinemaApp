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
        private readonly IScheduleRepository _scheduleRepository;

        public HomeController(ILogger<HomeController> logger,IMoviesRepository moviesRepository,IScheduleRepository scheduleRepository)
        {

            _logger = logger;
            _moviesRepository = moviesRepository;
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Index()
        {
            var newest = _moviesRepository.GetAllMovies().Take(5).ToList();
            var recomment = _moviesRepository.GetAllMovies().Take(4).ToList();

            var model = new HomeIndexViewModel
            {
                NewestMovies = newest,
                RecommendMovies = recomment
            };
            return View(model);
        }

        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult Repeitorie(DateTime? selectedDate)
        {
            DateTime date = selectedDate ?? DateTime.Today;

            var model = _scheduleRepository.GetScheduleByDate(date).ToList();
            return View(model);
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

        public IActionResult PurchaseTicket(int ticketId)
        {
            return RedirectToAction("Index","Ticket",new { id = ticketId});
        }

    }
}