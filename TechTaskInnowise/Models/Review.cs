using System.ComponentModel.DataAnnotations;

namespace InnowiseTechTask.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
    }
}
