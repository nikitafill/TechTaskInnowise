using TechTaskInnowise.Models;
using TechTaskInnowise.Models.DTOs;

namespace TechTaskInnowise.IRepositories
{
    public interface IActorRepositories : IGenericRepositories<Actor>  
    {
        Task<List<Actor>> GetListAsync(bool includeFilms = false);
        Task<Actor> GetAsync(int id, bool includeFilms = false);
    }
}
