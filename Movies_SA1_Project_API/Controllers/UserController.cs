﻿using Microsoft.AspNetCore.Mvc;
using Movies_SA1_Project_API.DTOs;
using Movies_SA1_Project_API.Services;

namespace Movies_SA1_Project_API.Controllers
{

    // the main api endpoints for the user

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            // initalize object from the user service to deal with incoming data
            _userService = userService;
        }



        // register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userReg)
        {
            var user = await _userService.Register(userReg);

            if (user.Equals("Registered Successfully"))
            {
                return Ok(user);
            }
            return BadRequest(user);
        }

        // login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto userLog)
        {
            var user = await _userService.Login(userLog);

            if (user.Equals("Logged In!"))
            {
                return Ok(userLog);
            }
            if(user.Equals("User Does Not Exist.Please register First"))
            {
                return NotFound(user);
            }
            return BadRequest(user);
        }
    }
}
