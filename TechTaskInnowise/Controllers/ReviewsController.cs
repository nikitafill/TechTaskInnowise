using TechTaskInnowise.Data;
using TechTaskInnowise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.Models;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepositories _reviewRepository;

        public ReviewsController(IReviewsRepositories reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        // GET: ActorsController
        // GET: api/Actors
        [HttpGet]
        public async Task<IActionResult> GetReviewsList()
        {
            var reviews = await _reviewRepository.GetListAsync();
            return Ok(reviews.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewRepository.GetAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost]
        [Route("CreateActor")]
        public async Task<IActionResult> CreateReviewAsync([FromBody] AddReviewDTO addReviewDTO)
        {
            var review = new Review
            {
                Title = addReviewDTO.Title,
                Description = addReviewDTO.Description,
                Stars = addReviewDTO.Stars,
            };
            await _reviewRepository.AddAsync(review);
            return Ok(review);
        }
        [HttpPut]
        [Route("UpdateActor")]
        public async Task<IActionResult> UpdateReviewAsync([FromBody] UpdReviewDTO updReviewDTO, int id)
        {
            var review = await _reviewRepository.GetAsync(id);

            if (id != review.Id)
            {
                return BadRequest();
            }
            if (review != null)
            {
                review.Title = updReviewDTO.Title;
                review.Description = updReviewDTO.Description;
                review.Stars = updReviewDTO.Stars;

                await _reviewRepository.UpdateAsync(review);
                return Ok(review);
            }

            return NotFound();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _reviewRepository.GetAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            await _reviewRepository.DeleteAsync(review);
            return Ok();
        }
    }
}
