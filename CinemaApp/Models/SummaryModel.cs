namespace CinemaApp.Models
{
    public class SummaryModel
    {
        public List<ReservationModel> Reservations { get; set; }
        public ScheduleModel Schedule { get; set; }
       public string? PDFUrl { get; set; }
    }
}
