using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepositories _actorRepository;
        private readonly ILogger<ActorsController> _logger;

        public ActorsController(IActorRepositories actorRepository, ILogger<ActorsController> logger)
        {
            _actorRepository = actorRepository;
            _logger = logger;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<IActionResult> GetActorsList()
        {
            try
            {
                var actors = await _actorRepository.GetListAsync(includeFilms: true);
                return Ok(actors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting actors list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActor(int id)
        {
            try
            {
                var actor = await _actorRepository.GetAsync(id, includeFilms: true);
                if (actor == null)
                {
                    return NotFound();
                }
                return Ok(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting actor with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // POST: api/Actors/CreateActor
        [HttpPost("CreateActor")]
        public async Task<IActionResult> CreateActorAsync([FromBody] AddActorDTO addActorDTO)
        {
            try
            {
                var actor = new Actor
                {
                    FirstName = addActorDTO.FirstName,
                    LastName = addActorDTO.LastName
                };
                await _actorRepository.AddAsync(actor);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating actor.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // PUT: api/Actors/UpdateActor/5
        [HttpPut("UpdateActor/{id}")]
        public async Task<IActionResult> UpdateActorAsync(int id, [FromBody] UpdActorDTO updActorDTO)
        {
            try
            {
                var actor = await _actorRepository.GetAsync(id);
                if (actor == null)
                {
                    return NotFound();
                }

                actor.FirstName = updActorDTO.FirstName;
                actor.LastName = updActorDTO.LastName;

                await _actorRepository.UpdateAsync(actor);
                return Ok(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating actor with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        // DELETE: api/Actors/DeleteActor/5
        [HttpDelete("DeleteActor/{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                var actor = await _actorRepository.GetAsync(id);
                if (actor == null)
                {
                    return NotFound();
                }

                await _actorRepository.DeleteAsync(actor);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting actor with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}

