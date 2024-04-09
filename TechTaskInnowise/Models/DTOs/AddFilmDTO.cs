using System.ComponentModel.DataAnnotations;
using TechTaskInnowise.Models;

namespace TechTaskInnowise.Models.DTOs
{
    public class AddFilmDTO
    {
        public int Id;
        public string Title { get; set; }
        public int Year { get; set; }
        public List<int> ActorIds { get; set; }
        //public List<Actor> Actors { get; set; }
        /*public AddFilmDTO()
        {
            Actors = new List<Actor>();
        }
        public ICollection<Actor> Actors { get; set; }*/
        //public ICollection<Review> Reviews { get; set; }
    }
}
