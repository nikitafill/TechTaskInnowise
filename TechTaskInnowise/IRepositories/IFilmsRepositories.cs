using TechTaskInnowise.Models;

namespace TechTaskInnowise.IRepositories
{
    public interface IFilmsRepositories : IGenericRepositories<Film>
    {
        Task<List<Film>> GetListAsync(bool includeActors = false);
        Task<Film> GetAsync(int id, bool includeActors = false);
    }
}
