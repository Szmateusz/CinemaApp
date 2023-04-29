using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Models
{
    public class MovieModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Reżyser")]
        public string Director { get; set; }
        [Display(Name = "Kategoria")]

        public Enums.Category Category { get; set; }
        [Display(Name = "Kategoria wiekowa")]

        public Enums.AgeCategory AgeCategory { get; set; }
        [Display(Name = "Długość")]

        public int LengthInMin { get; set; }
        [Display(Name = "Data premiery")]

        public DateTime PremiereDate { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "Ocena")]

        public float Rating { get; set; }

        public List<ActorModel> Actors { get; set; }

        public List<ScheduleModel> Schedules { get; set; }
        public List<ReviewModel> Reviews { get; set; }

    }
}
