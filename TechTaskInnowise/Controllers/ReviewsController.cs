using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTaskInnowise.Data;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewsRepositories _reviewRepository;
        private readonly ILogger<ReviewsController> _logger;

        public ReviewsController(IReviewsRepositories reviewRepository, ILogger<ReviewsController> logger)
        {
            _reviewRepository = reviewRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsList()
        {
            try
            {
                var reviews = await _reviewRepository.GetListAsync();
                return Ok("Отывы добавлены" + reviews);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting reviews list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            try
            {
                var review = await _reviewRepository.GetAsync(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting review with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReviewAsync([FromBody] AddReviewDTO addReviewDTO)
        {
            try
            {
                var review = new Review
                {
                    Title = addReviewDTO.Title,
                    Description = addReviewDTO.Description,
                    Stars = addReviewDTO.Stars,
                    FilmId = addReviewDTO.FilmId,
                };
                await _reviewRepository.AddAsync(review);
                return Ok(review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating review.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("UpdateReview/{id}")]
        public async Task<IActionResult> UpdateReviewAsync(int id, [FromBody] UpdReviewDTO updReviewDTO)
        {
            try
            {
                var review = await _reviewRepository.GetAsync(id);
                if (review == null)
                {
                    return NotFound();
                } 

                review.Title = updReviewDTO.Title;
                review.Description = updReviewDTO.Description;
                review.Stars = updReviewDTO.Stars;
                review.FilmId = updReviewDTO.FilmId;

                await _reviewRepository.UpdateAsync(review);
                return Ok(review);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating review with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("DeleteReview/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var review = await _reviewRepository.GetAsync(id);
                if (review == null)
                {
                    return NotFound();
                }

                await _reviewRepository.DeleteAsync(review);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting review with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}

