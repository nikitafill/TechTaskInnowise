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
    }
}
