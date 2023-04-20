namespace CinemaApp.Models
{
    public class ReviewModel
    {

        public int ID { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
