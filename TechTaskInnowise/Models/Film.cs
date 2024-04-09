using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using TechTaskInnowise.Models;

namespace TechTaskInnowise.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public  virtual ICollection<Actor> Actors { get; set; }
        public  ICollection<Review> Reviews { get; set; }
        public Film()
        {
            Actors = new List<Actor>();
            Reviews = new List<Review>();
        }
    }
}
