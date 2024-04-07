using Microsoft.AspNetCore.Mvc;
using TechTaskInnowise.Models;
using System.Linq;
using TechTaskInnowise.Data;
using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly IFilmsRepositories _filmRepository;

        public FilmsController(IFilmsRepositories filmRepository)
        {
            _filmRepository = filmRepository;
        }
        // GET: ActorsController
        // GET: api/Actors
        [HttpGet]
        public async Task<IActionResult> GetFilmsList()
        {
            var films = await _filmRepository.GetListAsync();
            return Ok(films.ToList());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _filmRepository.GetAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }
        [HttpPost]
        [Route("CreateActor")]
        public async Task<IActionResult> CreateFilmAsync([FromBody] AddFilmDTO addFilmDTO)
        {
            var film = new Film
            {
                Title = addFilmDTO.Title,
                Year = addFilmDTO.Year,
            };
            await _filmRepository.AddAsync(film);
            return Ok(film);
        }
        [HttpPut]
        [Route("UpdateActor")]
        public async Task<IActionResult> UpdateFilmAsync([FromBody] UpdFilmDTO updFilmDTO, int id)
        {
            var film = await _filmRepository.GetAsync(id);

            if (id != film.Id)
            {
                return BadRequest();
            }
            if (film != null)
            {
                film.Title = film.Title;
                film.Year = film.Year;

                await _filmRepository.UpdateAsync(film);
                return Ok(film);
            }

            return NotFound();
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _filmRepository.GetAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            await _filmRepository.DeleteAsync(film);
            return Ok();
        }
    }
}