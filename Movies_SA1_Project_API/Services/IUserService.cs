using Movies_SA1_Project_API.DTOs;

namespace Movies_SA1_Project_API.Services
{
    // User Interface (Main Functions)
    public interface IUserService
    {
        Task<string> Register(UserRegisterDto newUser);
        Task<string> Login(UserLoginDto exUser);
    }
}
