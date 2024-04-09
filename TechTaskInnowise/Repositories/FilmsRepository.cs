using Microsoft.EntityFrameworkCore;
using TechTaskInnowise.Data;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models;

namespace TechTaskInnowise.Repositories
{
    public class FilmsRepository : GenericsRepositories<Film>, IFilmsRepositories
    {
        private readonly ApplicationDbContext _context;
        public FilmsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Film>> GetListAsync(bool includeFilms = false)
        {
            if (includeFilms)
            {
                return await _context.Films
                    .Select(a => new Film
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Year = a.Year,
                        Actors = a.Actors.Select(f => new Actor
                        {
                            Id = f.Id,
                            FirstName = f.FirstName,
                            LastName = f.LastName
                        }).ToList()
                    })
                    .ToListAsync();
            }
            else
            {
                return await _context.Films.ToListAsync();
            }
        }
        public async Task<Film> GetAsync(int id, bool includeFilms = false)
        {
            if (includeFilms)
            {
                return await _context.Films
                    .Where(a => a.Id == id)
                    .Select(a => new Film
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Year = a.Year,
                        Actors = a.Actors.Select(f => new Actor
                        {
                            Id = f.Id,
                            FirstName = f.FirstName,
                            LastName = f.LastName
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Films.FindAsync(id);
            }
        }
    }
}
