namespace CinemaApp.Models
{
    public class ReservationModel
    {
        public int ID { get; set; }

        public int SeanceID { get; set; }
        public ScheduleModel Seance { get; set; }

        public int Row { get; set; }
        public int Place { get; set; }

        public DateTime ReservationDate { get; set; }
        public Enums.PriceList Price { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
