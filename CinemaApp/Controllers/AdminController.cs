using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static System.Reflection.Metadata.BlobBuilder;

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
            var halls = _hallRepository.GetAllHalls().ToList();

            var model = new HallViewModel
            {
                Halls = halls            
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult HallView(HallViewModel model)
        {
            var halls = _hallRepository.GetAllHalls().ToList();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                halls = halls.Where(b => b.HallName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
                 
            }
            model.Halls= halls;
            return View(model);
        }
        [HttpGet]
        public IActionResult MoviesView()
        {
            var movies = _movieRepository.GetAllMovies().ToList();
            var model = new MoviesViewModel
            {
                Movies = movies
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult MoviesView(MoviesViewModel model)
        {
            var movies = _movieRepository.GetAllMovies().ToList();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                movies = movies.Where(b => b.Title.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                 b.Director.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||                            
                 b.Description.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();

            }
            if (!model.Category.ToString().Equals("All"))
            {
                movies = movies.Where(b => b.Category.Equals(model.Category.ToString())).ToList();
            }
            if (!model.AgeCategory.ToString().Equals("All"))
            {
                movies = movies.Where(b => b.AgeCategory.Equals(model.AgeCategory.ToString())).ToList();
            }
            model.Movies = movies;
            return View(model);
        }

        [HttpGet]
        public IActionResult SchedulesView()
        {
            var schedules = _scheduleRepository.GetAllSchedules().ToList();
            var model = new SchedulesViewModel
            {
                Schedules = schedules
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SchedulesView(SchedulesViewModel model)
        {
            var schedules = _scheduleRepository.GetAllSchedules().ToList();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                schedules = schedules.Where(b => b.Movie.Title.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                b.Hall.HallName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                 b.Movie.Description.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();

            }

            model.Schedules = schedules;
            return View(model);
        }
        [HttpGet]
        public IActionResult ActorsView()
        {
            var actors = _actorRepository.GetAllActors().ToList();

            var model = new ActorsViewModel
            {
                Actors = actors,
            };
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
            var reservations = _reservationsRepository.GetAllReservations().ToList();
            var model = new ReservationsViewModel
            {
                Reservations = reservations
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult ReservationsView(ReservationsViewModel model)
        {
            var reservations = _reservationsRepository.GetAllReservations().ToList();

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                reservations = reservations.Where(b => b.FirstName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                b.Phone.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                b.Email.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                b.Seance.Movie.Title.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                b.Seance.Hall.HallName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase) ||
                 b.LastName.Contains(model.SearchString, StringComparison.OrdinalIgnoreCase)).ToList();

            }

            model.Reservations = reservations;
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
