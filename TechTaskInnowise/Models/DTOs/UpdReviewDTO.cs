using TechTaskInnowise.Models;

namespace TechTaskInnowise.Models.DTOs
{
    public class UpdReviewDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
