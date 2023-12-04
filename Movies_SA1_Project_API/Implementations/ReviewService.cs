using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Data;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Implementations
{
    // The implementation of the Review interface
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;

        public ReviewService(DataContext context)
        {
            // Initailize the object to deal with the Review database
            _context = context;
        }

        public async Task<bool> AddReview(ReviewDto newRev)
        {
            // change from reviewDto to review
            var rev = new Review()
            {
                ReviewType = newRev.ReviewType,
                ReviewName = newRev.ReviewName,
                Name = newRev.ReviewName,
                Description = newRev.Description,
                Rating = newRev.Rating
            };
            
            // add review to the database
            await _context.Reviews.AddAsync(rev);
            await _context.SaveChangesAsync();
            return true;
        }

        // get all review from the database
        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
