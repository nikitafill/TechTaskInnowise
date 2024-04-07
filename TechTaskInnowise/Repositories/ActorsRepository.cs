using TechTaskInnowise.Data;
using TechTaskInnowise.Models;
using System;
using TechTaskInnowise.IRepositories;

namespace TechTaskInnowise.Repositories
{
    public class ActorsRepository: GenericsRepositories<Actor>, IActorRepositories
    {
        private readonly ApplicationDbContext _context;
        public ActorsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
