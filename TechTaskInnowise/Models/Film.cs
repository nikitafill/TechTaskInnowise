using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace InnowiseTechTask.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
