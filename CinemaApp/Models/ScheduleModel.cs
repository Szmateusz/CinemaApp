namespace CinemaApp.Models
{
    public class ScheduleModel
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public MovieModel Movie { get; set; }
        public int HallID { get; set; }
        public HallModel Hall { get; set; }
        public DateTime Date { get; set; }
        public int AvaiblePlacesCount { get; set; }

        public List<ReservationModel> Reservations { get; set; }
        
    }
}
