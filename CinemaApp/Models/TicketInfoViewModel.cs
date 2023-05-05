namespace CinemaApp.Models
{
    public class TicketInfoViewModel
    {
        public List<TicketModel> Tickets { get; set; }
        public ScheduleModel Schedule { get; set; }
        public CustomerDataModel Customer { get; set; }
    }
}
