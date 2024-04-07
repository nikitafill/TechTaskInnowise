using TechTaskInnowise.Data;
using TechTaskInnowise.IRepositories;
using TechTaskInnowise.Models;

namespace TechTaskInnowise.Repositories
{
    public class ReviewsRepository: GenericsRepositories<Review>, IReviewsRepositories
    {
        private readonly ApplicationDbContext _context;
        public ReviewsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
