using InnowiseTechTask.Data;
using InnowiseTechTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InnowiseTechTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: ActorsController
        // GET: api/Actors
        [HttpGet]
        public ActionResult<IEnumerable<Actor>> GetActors()
        {
            var actors = _context.Actors.ToList();
            return actors;
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public ActionResult<Actor> GetActor(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }
            return actor;
        }

        // POST: api/Actors
        [HttpPost]
        public ActionResult<Actor> CreateActor([FromBody] Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetActor), new { id = actor.Id }, actor);
        }

        // PUT: api/Actors/5
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }
            _context.Entry(actor).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
