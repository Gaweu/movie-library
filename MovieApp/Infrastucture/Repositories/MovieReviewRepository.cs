using MovieApp.DataAccess;
using MovieApp.Models;

namespace MovieApp.Infrastucture.Repositories
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        private readonly DatabaseContext _context;

        public MovieReviewRepository(DatabaseContext context)
        {
            _context = context;
        }
        public ICollection<MovieReview> GetReviewsById(int id)
        {
            List<MovieReview> reviewsById = _context.Reviews.Where(r => r.MovieId == id).ToList();
            return reviewsById;
        }

        public MovieReview InsertReview(int id, MovieReview review)
        {
            MovieReview reviewToAdd = new MovieReview()
            {
                MovieId = id,
                Username = review.Username,
                Review = review.Review,
                Rating = review.Rating
            };
            _context.Reviews.AddAsync(reviewToAdd);
            _context.SaveChanges();
            return review;
        }
    }
}
