using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Data;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Implementations
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddReview(ReviewDto newRev)
        {
            var rev = new Review()
            {
                ReviewType = newRev.ReviewType,
                ReviewName = newRev.ReviewName,
                Name = newRev.ReviewName,
                Description = newRev.Description,
                Rating = newRev.Rating
            };

            await _context.Reviews.AddAsync(rev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
