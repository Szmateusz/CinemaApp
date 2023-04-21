namespace CinemaApp.Models
{
    public class AddScheduleView
    {
        public List<MovieModel> Movies { get; set; }
        public List<HallModel> Halls { get; set; }
        public DateTime Date { get; set; }

    }
}
