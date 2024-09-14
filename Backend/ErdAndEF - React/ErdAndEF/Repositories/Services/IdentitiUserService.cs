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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;  // Inject RoleManager
        private readonly JwtTokenService jwtTokenService;

        public IdentitiUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.jwtTokenService = jwtTokenService;
        }

        // Register logic with roles
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
                // Ensure that at least one role is assigned
                var roles = registerdUserDto.Roles ?? new List<string> { "User" };  // Assign "User" role if none provided

                foreach (var role in roles)
                {
                    // Check if the role exists, and create if it doesn't
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }

                    var roleAssignResult = await _userManager.AddToRoleAsync(user, role);
                    if (!roleAssignResult.Succeeded)
                    {
                        foreach (var error in roleAssignResult.Errors)
                        {
                            modelState.AddModelError("", error.Description);
                        }
                        return null;
                    }
                }

                // Fetch roles assigned to the user
                var assignedRoles = await _userManager.GetRolesAsync(user);

                // Return user details including the roles
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = assignedRoles
                };
            }

            foreach (var error in result.Errors)
            {
                modelState.AddModelError("", error.Description);
            }

            return null;
        }

        // Login logic with JWT token generation
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
                    Token = await jwtTokenService.GenerateToken(user, TimeSpan.FromDays(1.0)),
                    Roles = roles // Add roles to the response
                };
            }

            // If password is invalid, log and return null
            Console.WriteLine("Password validation failed.");
            return null; // or return an appropriate response
        }

        // Fetch user profile logic
        public async Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);

            // Fetch user roles
            var roles = await _userManager.GetRolesAsync(user);

            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(60)),
                Roles = roles // Include roles in the response
            };
        }
    }
}
