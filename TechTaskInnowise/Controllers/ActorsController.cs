using TechTaskInnowise.Data;
using TechTaskInnowise.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Repositories;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly IActorRepositories _actorRepository;

        public ActorsController(IActorRepositories actorRepository)
        {
            _actorRepository = actorRepository;
        }
        // GET: ActorsController
        // GET: api/Actors
        [HttpGet]
        public async Task<IActionResult> GetActorsList() 
        {
            var actors = await _actorRepository.GetListAsync();
            return Ok(actors.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            var actor = await _actorRepository.GetAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return Ok(actor);
        }
        [HttpPost]
        [Route("CreateActor")]
        public async Task<IActionResult> CreateActorAsync([FromBody] AddActorDTO addActorDTO)
        {
            var actor = new Actor
            {
                FirstName = addActorDTO.FirstName,
                LastName = addActorDTO.LastName,
            };
            await _actorRepository.AddAsync(actor);
            return Ok(actor);
        }
        [HttpPut]
        [Route("UpdateActor")]
        public async Task<IActionResult> UpdateActorAsync([FromBody] UpdActorDTO updActorDTO,int id)
        {
            var actor= await _actorRepository.GetAsync(id);

            if (id != actor.Id)
            {
                return BadRequest();
            }
            if(actor !=null)
            {
                actor.FirstName = actor.FirstName;
                actor.LastName = actor.FirstName;

                await _actorRepository.UpdateAsync(actor);
                return Ok(actor);
            }

            return NotFound();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _actorRepository.GetAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            await _actorRepository.DeleteAsync(actor);
            return Ok();
        }
    }
}
