using TechTaskInnowise.Data;
using TechTaskInnowise.Models;
using System;
using TechTaskInnowise.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace TechTaskInnowise.Repositories
{
    public class ActorsRepository: GenericsRepositories<Actor>, IActorRepositories
    {
        private readonly ApplicationDbContext _context;
        public ActorsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Actor>> GetListAsync(bool includeFilms = false)
        {
            if (includeFilms)
            {
                return await _context.Actors
                    .Select(a => new Actor
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Films = a.Films.Select(f => new Film
                        {
                            Id = f.Id,
                            Title = f.Title,
                            Year = f.Year
                        }).ToList()
                    })
                    .ToListAsync();
            }
            else
            {
                return await _context.Actors.ToListAsync();
            }
        }
        public async Task<Actor> GetAsync(int id, bool includeFilms = false)
        {
            if (includeFilms)
            {
                return await _context.Actors
                    .Where(a => a.Id == id)
                    .Select(a => new Actor
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        Films = a.Films.Select(f => new Film
                        {
                            Id = f.Id,
                            Title = f.Title,
                            Year = f.Year
                        }).ToList()
                    })
                    .FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Actors.FindAsync(id);
            }
        }


    }
}
