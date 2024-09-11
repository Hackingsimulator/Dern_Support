using ErdAndEF.Models;
using ErdAndEF.Models.DTO;
using ErdAndEF.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ErdAndEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUser userService;

        public UsersController(IUser context)
        {
            userService = context;
        }



    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterdUserDto registerdUserDto)
    {
        var user = await userService.Register(registerdUserDto, this.ModelState);

        if (!ModelState.IsValid)
        {
            // Log ModelState errors
            Console.WriteLine("ModelState Invalid: " + ModelState);
            return BadRequest(ModelState);
        }

        if (user == null)
        {
            // Log if user registration failed for any reason
            Console.WriteLine("User registration failed.");
            return Unauthorized();
        }

        return Ok(user);
    }



        // login 
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        // Check if the loginDto is null
        if (loginDto == null)
        {
            Console.WriteLine("Received null login data.");
            return BadRequest(new { Message = "Login data is required." });
        }

        // Check if both username and password are provided
        if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
        {
            return BadRequest(new { Message = "Username and password are required." });
        }

        // Perform user authentication
        var user = await userService.UserAuthentication(loginDto.Username, loginDto.Password);

        // Check if authentication failed
        if (user == null)
        {
            Console.WriteLine($"Authentication failed for user: {loginDto.Username}");
            return Unauthorized(new { Message = "Invalid username or password." });
        }

        // Return the authenticated user details with token
        return Ok(user);
    }



    [Authorize(Roles = "User", Policy = "CanDelete")]
    [HttpGet("Profile")]
    public async Task<ActionResult<UserDto>> Profile()
    {
        // Get the user's profile using the claims from the token
        var userProfile = await userService.userProfile(User);
        Console.WriteLine(userProfile);

        // Return the user profile or Unauthorized if not found
        if (userProfile == null)
        {
            return Unauthorized();
        }

        return Ok(userProfile);
    }



        //[Authorize(Roles = "Admin")] 
        //[HttpGet("GetAllTasks")]
        //public async Task<ActionResult<IEnumerable<Task>>> GetAllTasks()
        //{
        //    var tasks = await userService.Tasks.ToListAsync();
        //    return Ok(tasks);
        //}


    }
}
