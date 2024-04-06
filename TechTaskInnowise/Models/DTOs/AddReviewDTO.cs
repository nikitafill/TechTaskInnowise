using InnowiseTechTask.Models;

namespace TechTaskInnowise.Models.DTOs
{
    public class AddReviewDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
