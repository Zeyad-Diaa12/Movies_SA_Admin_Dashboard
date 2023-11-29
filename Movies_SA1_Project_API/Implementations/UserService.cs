using Microsoft.EntityFrameworkCore;
using Movies_SA1_Project_API.Data;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Models;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> Login(UserLoginDto exUser)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == exUser.Email);

            if (existingUser == null)
            {
                return "User Does Not Exist.Please register First";
            }

            if(exUser.Password == existingUser.Password)
            {
                return "Logged In!";
            }
            else
            {
                return "Wrong Password!";
            }

            return "Something Unexpected Happened";
        }

        public async Task<string> Register(UserRegisterDto newUser)
        {
            try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

                if (existingUser != null)
                    return "User Already Exists";
                if (newUser.Password == newUser.ConfirmPassword)
                {
                    var user = new User
                    {
                        Email = newUser.Email,
                        Password = newUser.Password
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    return "Registered Successfully";

                }
                return "Passwords Does Not Match";
            }
            catch (Exception)
            {
                return "Something Wrong Happened";
            }
        }
    }
}
