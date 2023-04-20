namespace CinemaApp.Models
{
    public class HallModel
    {
        public int ID { get; set; }
        public string HallName { get; set; }
        public int Places { get; set; }
        public List<ScheduleModel> Schedules { get; set; }
    }
}
