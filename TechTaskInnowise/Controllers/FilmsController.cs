using Microsoft.AspNetCore.Mvc;
using TechTaskInnowise.Models;
using System.Linq;
using TechTaskInnowise.Data;
using Microsoft.EntityFrameworkCore;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ActorsController
        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetFilms()
        {
            var films = _context.Films.ToList();
            return films;
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetFilm(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            return film;
        }

        [HttpPost]
        public ActionResult<Actor> CreateFilm([FromBody] Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilm), new { id = film.Id }, film);
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public IActionResult UpdateFilm(int id, [FromBody] Film film)
        {
            if (id != film.Id)
            {
                return BadRequest();
            }
            _context.Entry(film).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            var film = _context.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            _context.Films.Remove(film);
            _context.SaveChanges();
            return NoContent();
        }
    }
}