using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastucture.Models;
using MovieApp.Infrastucture.Repositories;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {

        private readonly ILogger<MoviesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public MoviesController(ILogger<MoviesController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int page)
        {
            List<Movie> movies = new List<Movie>();
            var httpClient = _httpClientFactory.CreateClient();
            var URL = $"https://api.themoviedb.org/3/movie/popular?api_key=96891f6931b94d9a63477ed86dbc3f99&language=en-US&page={page}";
            var response = await httpClient.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();
            MovieHelper moviesPerPage = JsonConvert.DeserializeObject<MovieHelper>(result);
            movies = moviesPerPage.results;

            return Ok(movies);
             
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById(int id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var URL = $"https://api.themoviedb.org/3/movie/{id}?api_key=96891f6931b94d9a63477ed86dbc3f99";
            var response = await httpClient.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();
            Movie movie = JsonConvert.DeserializeObject<Movie>(result);

            return Ok(movie);
        }

        [HttpGet("{action}/{name}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByName(string name, int page)
        {
            List<Movie> movies = new List<Movie>();
            var httpClient = _httpClientFactory.CreateClient();
            var URL = $"https://api.themoviedb.org/3/search/movie?api_key=96891f6931b94d9a63477ed86dbc3f99&query={name}&page={page}";
            var response = await httpClient.GetAsync(URL);
            var result = await response.Content.ReadAsStringAsync();
            MovieHelper moviesPerPage = JsonConvert.DeserializeObject<MovieHelper>(result);
            movies = moviesPerPage.results;

            return Ok(movies);
        }



    }
}