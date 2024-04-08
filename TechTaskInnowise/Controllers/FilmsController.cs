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
    public class FilmsController : ControllerBase
    {
        private readonly IFilmsRepositories _filmRepository;
        private readonly ILogger<FilmsController> _logger;

        public FilmsController(IFilmsRepositories filmRepository, ILogger<FilmsController> logger)
        {
            _filmRepository = filmRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmsList()
        {
            try
            {
                var films = await _filmRepository.GetListAsync();
                return Ok(films);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting films list.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            try
            {
                var film = await _filmRepository.GetAsync(id);
                if (film == null)
                {
                    return NotFound();
                }
                return Ok(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting film with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost("CreateFilm")]
        public async Task<IActionResult> CreateFilmAsync([FromBody] AddFilmDTO addFilmDTO)
        {
            try
            {
                var film = new Film
                {
                    Title = addFilmDTO.Title,
                    Year = addFilmDTO.Year,
                };
                await _filmRepository.AddAsync(film);
                return Ok(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating film.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("UpdateFilm/{id}")]
        public async Task<IActionResult> UpdateFilmAsync(int id, [FromBody] UpdFilmDTO updFilmDTO)
        {
            try
            {
                var film = await _filmRepository.GetAsync(id);
                if (film == null)
                {
                    return NotFound();
                }

                film.Title = updFilmDTO.Title;
                film.Year = updFilmDTO.Year;

                await _filmRepository.UpdateAsync(film);
                return Ok(film);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating film with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("DeleteFilm/{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            try
            {
                var film = await _filmRepository.GetAsync(id);
                if (film == null)
                {
                    return NotFound();
                }

                await _filmRepository.DeleteAsync(film);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting film with ID {id}.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
