

namespace Movies_SA1_Project_API.DTOs
{
    // DTO (Data Transfer Object) for review
    public class ReviewDto
    {
        public string ReviewType { get; set; }
        public string ReviewName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
