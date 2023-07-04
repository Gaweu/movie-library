namespace MovieApp.Models
{
    public class MovieReview
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Username { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }


    }
}
