using MovieApp.DataAccess;
using MovieApp.Infrastucture.Models;

namespace MovieApp.Infrastucture.Repositories
{
    public class MovieRecommendedRepository : IMovieRecommendedRepository
    {
        private readonly DatabaseContext _context;

        public MovieRecommendedRepository(DatabaseContext context)
        {
            _context = context;
        }
        public ICollection<MovieRecommended> GetRecommendations()
        {
            List<MovieRecommended> recommendedMovies = _context.Recommendations.ToList();
            return recommendedMovies;
        }

        public MovieRecommended InsertRecommendation(int id)
        {
            if(_context.Recommendations.Any(r => r.MovieId == id))
            {
                return null;
            }
            else
            {
                MovieRecommended recommendationToAdd = new MovieRecommended()
                {
                    MovieId = id,
                };
                _context.Recommendations.AddAsync(recommendationToAdd);
                _context.SaveChanges();
            }
            return null;
        }
    }
}
