using InnowiseTechTask.Data;
using InnowiseTechTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnowiseTechTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ActorsController
        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetReviews()
        {
            var reviews = _context.Reviews.ToList();
            return reviews;
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        [HttpPost]
        public ActionResult<Actor> CreateReview([FromBody] Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return CreatedAtAction(nameof(CreateReview), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }
            _context.Entry(review).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
