namespace CinemaApp.Models
{
    public class ActorModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }

        public List<MovieModel> Movies { get; set; }

    }
}
