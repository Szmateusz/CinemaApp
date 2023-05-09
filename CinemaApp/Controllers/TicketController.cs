using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Controllers
{
    public class TicketController : Controller
    {
        public readonly IReservationsRepository _reservationsRepository;
        public readonly IScheduleRepository _scheduleRepository;
        public readonly EmailSender _emailSender;

        public TicketController(IScheduleRepository scheduleRepository, EmailSender emailSender, IReservationsRepository reservationsRepository)
        {

            _scheduleRepository = scheduleRepository;
            _emailSender = emailSender;
            _reservationsRepository = reservationsRepository;
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
        [HttpPost]
        public IActionResult TicketPayment(TicketInfoViewModel model)
        {
           
            model.Schedule = _scheduleRepository.GetScheduleById(model.Schedule.ID);
            return View(model);
        }
        [HttpPost]
        public IActionResult Summary(TicketInfoViewModel model)
        {
            var schedule = _scheduleRepository.GetScheduleById(model.Schedule.ID);

            List<ReservationModel> reservations = new List<ReservationModel>();

            foreach (var res in model.Tickets)
            {
                var r = new ReservationModel
                {
                    SeanceID = schedule.ID,
                    Row = res.Row,
                    Place = res.Place,
                    ReservationDate = DateTime.Now,
                    FirstName = model.Customer.FirstName,
                    LastName = model.Customer.LastName,
                    Phone = model.Customer.Phone,
                    Email = model.Customer.Email


                };
                reservations.Add(r);
            }
            var summaryModel = new SummaryModel
            {
                Reservations = reservations,
                Schedule = schedule
                
            };


            if (!AddReservation(summaryModel))
            {
                return NotFound();
            }

            if (!PDFClass.DownloadPdf(summaryModel)) { return NotFound(); }

            var emailSubject = "Zakup biletów";
            var emailMessage = $"Zakup biletów na seans \"{summaryModel.Schedule.Movie}\" przez klienta {model.Customer.FirstName} {model.Customer.LastName}";

            if (!_emailSender.SendEmail(model.Customer.Email, emailSubject, emailMessage,summaryModel.PDFUrl))  {  return NotFound();  }

            return View("Summary", summaryModel);

        }
        public bool AddReservation(SummaryModel summaryModel)
        {
            try
            {
                foreach (var res in summaryModel.Reservations)
                {
                    _reservationsRepository.AddReservation(res);

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
            
        }

        
    }
}
