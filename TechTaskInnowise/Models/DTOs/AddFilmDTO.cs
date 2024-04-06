using System.ComponentModel.DataAnnotations;

namespace InnowiseTechTask.Models.DTOs
{
    public class AddFilmDTO
    {
        public int Id;
        public string Title { get; set; }
        public int Year { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
