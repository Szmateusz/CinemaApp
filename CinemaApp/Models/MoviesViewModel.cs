namespace CinemaApp.Models
{
    public class MoviesViewModel
    {
        public List<MovieModel> Movies;
        public string SearchString { get; set; }
        public Enums.Category Category { get; set; }
        public Enums.AgeCategory AgeCategory { get; set; }

    }
}
