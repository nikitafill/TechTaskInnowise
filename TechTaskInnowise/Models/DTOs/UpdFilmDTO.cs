using TechTaskInnowise.Models;

namespace TechTaskInnowise.Models.DTOs
{
    public class UpdFilmDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<int> ActorIds { get; set; }
    }
}
