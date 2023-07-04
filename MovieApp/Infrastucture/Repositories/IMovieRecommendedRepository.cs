using MovieApp.Infrastucture.Models;

namespace MovieApp.Infrastucture.Repositories
{
    public interface IMovieRecommendedRepository
    {
        ICollection<MovieRecommended> GetRecommendations();
        MovieRecommended InsertRecommendation(int id);

    }
}
