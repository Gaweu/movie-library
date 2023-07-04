using MovieApp.Models;

namespace MovieApp.Infrastucture.Repositories
{
    public interface IMovieReviewRepository
    {
        ICollection<MovieReview> GetReviewsById(int id);
        MovieReview InsertReview(int id, MovieReview review);
    }
}
