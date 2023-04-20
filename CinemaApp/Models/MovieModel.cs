using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class MovieModel
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public Enums.AgeCategory Category { get; set; }
        public Enums.AgeCategory AgeCategory { get; set; }
        public int LengthInMin { get; set; }
        public DateOnly PremiereDate { get; set; }
        public string ImageUrl { get; set; }
        public float Rating { get; set; }

        public List<ActorModel> Actors { get; set; }

        public List<ScheduleModel> Schedules { get; set; }
        public List<ReviewModel> Reviews { get; set; }

    }
}
