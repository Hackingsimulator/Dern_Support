using ErdAndEF.Models;
using ErdAndEF.Models.DTO;
using ErdAndEF.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace ErdAndEF.Repositories.Services
{
    public class IdentitiUserService : IUser
    {

        private UserManager<ApplicationUser> _userManager;

        // inject jwt service
        private JwtTokenService jwtTokenService;
        public IdentitiUserService(UserManager<ApplicationUser> Manager, JwtTokenService jwtTokenService)
        {
            _userManager = Manager;
            this.jwtTokenService = jwtTokenService;
        }

    public async Task<UserDto> Register(RegisterdUserDto registerdUserDto, ModelStateDictionary modelState)
    {
        var user = new ApplicationUser
        {
            UserName = registerdUserDto.UserName,
            Email = registerdUserDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

        if (result.Succeeded)
        {
            // Ensure that a default role is assigned (e.g., "User")
            var role = registerdUserDto.Roles.FirstOrDefault() ?? "user";  // Assign "User" role if none provided
            var roleAssignResult = await _userManager.AddToRoleAsync(user, role);

            if (!roleAssignResult.Succeeded)
            {
                foreach (var error in roleAssignResult.Errors)
                {
                    modelState.AddModelError("", error.Description);
                }
                return null;
            }

            // Fetch roles assigned to the user
            var roles = await _userManager.GetRolesAsync(user);

            // Return user details including the roles
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Roles = roles
            };
        }

        foreach (var error in result.Errors)
        {
            modelState.AddModelError("", error.Description);
        }

        return null;
    }



    
    public async Task<UserDto> UserAuthentication(string username, string password)
    {
        Console.WriteLine("Inside the userAuth func");

        // Check if the user exists
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return null; // or return an appropriate response
        }

        // Validate the password
        bool passValidation = await _userManager.CheckPasswordAsync(user, password);
        Console.WriteLine("Password validation result: " + passValidation);

        if (passValidation)
        {
            // Fetch user roles
            var roles = await _userManager.GetRolesAsync(user);
            Console.WriteLine("User roles: " + string.Join(", ", roles));

            // Generate and return the token if the password is valid, along with user roles
            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(60)),
                Roles = roles // Add roles to the response
            };
        }

        // If password is invalid, log and return null
        Console.WriteLine("Password validation failed.");
        return null; // or return an appropriate response
    }



        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
        var user = await _userManager.GetUserAsync(claimsPrincipal);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(60)) 
                
            };
        }
    }
}
