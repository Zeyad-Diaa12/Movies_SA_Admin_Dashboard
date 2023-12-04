namespace Movies_SA1_Project_API.DTOs
{
    // DTO (Data Transfer Object) for user register
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
