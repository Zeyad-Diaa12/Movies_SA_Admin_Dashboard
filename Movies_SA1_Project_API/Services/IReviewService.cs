using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;

namespace Movies_SA1_Project_API.Services
{
    // Review Interface (Main Functions)
    public interface IReviewService
    {
        Task<bool> AddReview(ReviewDto newRev);
        Task<IEnumerable<Review>> GetAll(); 
    }
}
