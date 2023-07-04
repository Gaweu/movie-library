using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Infrastucture.Repositories;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMovieReviewRepository _movieReviewRepository;

        public ReviewsController(IMovieReviewRepository movieReviewRepository)
        {
            _movieReviewRepository = movieReviewRepository;
        }

        public MovieReviewRepository MovieReviewRepository { get; }

        [HttpPost]
        public ActionResult<MovieReview> AddReview(int id, [FromBody] MovieReview review)
        {
            _movieReviewRepository.InsertReview(id, review);
            return Ok(review);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MovieReview>> GetReviewsById(int id)
        {
            List<MovieReview> reviewsById = _movieReviewRepository.GetReviewsById(id).ToList();
            return Ok(reviewsById);
        }
    }
}
