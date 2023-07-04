using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.DataAccess;
using MovieApp.Infrastucture.Models;
using MovieApp.Infrastucture.Repositories;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesRecommendedController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMovieRecommendedRepository _movieRecommendedRepository;

        public MoviesRecommendedController(IHttpClientFactory httpClientFactory, IMovieRecommendedRepository movieRecommendedRepository)
        {
            _httpClientFactory = httpClientFactory;
            _movieRecommendedRepository = movieRecommendedRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetRecommendedMovies()
        {

            List<MovieRecommended> recommendedMovies = _movieRecommendedRepository.GetRecommendations().ToList();

            var movies = new List<Movie>();

            foreach (MovieRecommended recomended in recommendedMovies)
            {
                var httpClient = _httpClientFactory.CreateClient();
                var URL = $"https://api.themoviedb.org/3/movie/{recomended.MovieId}?api_key=96891f6931b94d9a63477ed86dbc3f99";
                var response = await httpClient.GetAsync(URL);
                var result = await response.Content.ReadAsStringAsync();
                Movie movie = JsonConvert.DeserializeObject<Movie>(result);

                movies.Add(movie);
            }

            return Ok(movies);

        }

        [HttpPost]
        public ActionResult<MovieReview> AddRecommendation(int id)
        {
            _movieRecommendedRepository.InsertRecommendation(id);
            return Ok();
        }






    }
}
