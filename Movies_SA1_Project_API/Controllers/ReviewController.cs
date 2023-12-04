using Microsoft.AspNetCore.Mvc;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add-review")]
        public async Task<IActionResult> AddReview([FromForm]ReviewDto newRev)
        {
            var rev = await _reviewService.AddReview(newRev);

            if (rev)
            {
                return Ok("Review Added");
            }

            return BadRequest("Something Went Wrong");
        }


        [HttpGet("get-reviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            return Ok(await _reviewService.GetAll());
        }
    }
}
