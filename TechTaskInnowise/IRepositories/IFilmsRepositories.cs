using TechTaskInnowise.Models;

namespace TechTaskInnowise.IRepositories
{
    public interface IFilmsRepositories : IGenericRepositories<Film>
    {
        Task<List<Film>> GetListAsync(bool includeFilms = false);
        Task<Film> GetAsync(int id, bool includeFilms = false);
    }
}
