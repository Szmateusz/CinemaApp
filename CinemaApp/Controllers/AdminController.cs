using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CinemaApp.Controllers
{
   // [Authorize(Roles = "admin", AuthenticationSchemes = "Identity.Application")]
    public class AdminController : Controller
    {
        public readonly DBContext _context;
        public readonly IMoviesRepository _movieRepository;
        public readonly IScheduleRepository _scheduleRepository;
        public readonly IHallRepository _hallRepository;
        public readonly IReservationsRepository _reservationsRepository;
        public readonly IActorsRepository _actorRepository;




        public AdminController(DBContext context, IMoviesRepository moviesRepository, IScheduleRepository scheduleRepository,
            IHallRepository hallRepository, IReservationsRepository reservationsRepository, IActorsRepository actorRepository)
        {
            _context = context;
            _movieRepository = moviesRepository;
            _scheduleRepository = scheduleRepository;
            _hallRepository = hallRepository;
            _reservationsRepository = reservationsRepository;
            _actorRepository = actorRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region View

        [HttpGet]
        public IActionResult HallView()
        {
            var model = _hallRepository.GetAllHalls();
            return View(model);
        }
        [HttpPost]
        public IActionResult HallView()
        {
            var model = _hallRepository.GetAllHalls();
            return View(model);
        }
        [HttpGet]
        public IActionResult MoviesView()
        {
            var model = _movieRepository.GetAllMovies();
            return View(model);
        }
        [HttpPost]
        public IActionResult MoviesView()
        {
            var model = _movieRepository.GetAllMovies();
            return View(model);
        }

        [HttpGet]
        public IActionResult SchedulesView()
        {
            var model = _scheduleRepository.GetAllSchedules();
            return View(model);
        }
        [HttpPost]
        public IActionResult SchedulesView()
        {
            var model = _scheduleRepository.GetAllSchedules();
            return View(model);
        }
        [HttpGet]
        public IActionResult ActorsView()
        {
            var model = _scheduleRepository.GetAllSchedules();

            return View(model);
        }
        [HttpPost]
        public IActionResult ActorsView(ActorsViewModel model)
        {
            var actors = _actorRepository.GetAllActors().ToList();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                actors = actors.Where(b => b.FirstName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                 b.LastName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
                 
            }

            model.Actors = actors;
            return View(model);
        }
        [HttpGet]
        public IActionResult ReservationsView()
        {
            var model = _reservationsRepository.GetAllReservations();

            return View(model);
        }
        [HttpPost]
        public IActionResult ReservationsView()
        {
            var model = _reservationsRepository.GetAllReservations();

            return View(model);
        }
        public IActionResult ReservationDetail(int id)
        {
            var model = _reservationsRepository.GetReservationById(id);
            return View(model);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieModel movie)
        {
            _movieRepository.AddMovie(movie);
            return RedirectToAction("MoviesView", "Admin");

        }
        [HttpGet]
        public IActionResult AddHall()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHall(HallModel hall)
        {
            _hallRepository.AddHall(hall);
            return RedirectToAction("HallsView", "Admin");

        }

        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSchedule(ScheduleModel schedule)
        {
            _scheduleRepository.AddSchedule(schedule);
            return RedirectToAction("SchedulesView", "Admin");

        }
        [HttpGet]
        public IActionResult AddActor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddActor(ActorModel actor)
        {
            _actorRepository.AddActor(actor);
            return RedirectToAction("ActorsView", "Admin");
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult UpdateMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateMovie(MovieModel movie)
        {
            _movieRepository.UpdateMovie(movie);
            return RedirectToAction("MoviesView", "Admin");
        }
        [HttpGet]
        public IActionResult UpdateHall()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateHall(HallModel hall)
        {
            _hallRepository.UpdateHall(hall);
            return RedirectToAction("HallsView", "Admin");

        }
        [HttpGet]
        public IActionResult UpdateSchedule()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateSchedule(ScheduleModel schedule)
        {
            _scheduleRepository.UpdateSchedule(schedule);
            return RedirectToAction("SchedulesView", "Admin");

        }
        [HttpGet]
        public IActionResult UpdateActor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateActor(ActorModel actor)
        {
            _actorRepository.UpdateActor(actor);
            return RedirectToAction("ActorsView", "Admin");

        }
        #endregion

        #region Delete
        public IActionResult DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
            return RedirectToAction("MoviesView","Admin");
        }
        public IActionResult DeleteHall(int hallId)
        {
            _hallRepository.DeleteHall(hallId);
            return RedirectToAction("HallsView", "Admin");

        }
        public IActionResult DeleteSchedule(int scheduleId)
        {
            _scheduleRepository.DeleteSchedule(scheduleId);
            return RedirectToAction("SchedulesView", "Admin");

        }
        public IActionResult DeleteActor(int actorId)
        {
            _actorRepository.DeleteActor(actorId);
            return RedirectToAction("ActorsView", "Admin");
        }
        #endregion
    }
}
