namespace InnowiseTechTask.Models.DTOs
{
    public class UpdFilmDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }

        public ICollection<Actor> Actors { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
