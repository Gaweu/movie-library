namespace MovieApp.Infrastucture.Models
{
    public class MovieRecommended
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public bool isRecommended { get; set; }
    }
}
