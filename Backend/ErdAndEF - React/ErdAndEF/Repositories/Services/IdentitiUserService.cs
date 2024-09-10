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
            var user = new ApplicationUser()
            {
                UserName = registerdUserDto.UserName,
                Email = registerdUserDto.Email,
               

            };

            var result = await _userManager.CreateAsync(user, registerdUserDto.Password);

            if (result.Succeeded)
            {
                
                await _userManager.AddToRolesAsync(user, registerdUserDto.Roles);


                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user)
                    
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdUserDto) :
                                error.Code.Contains("Email") ? nameof(registerdUserDto) :
                                error.Code.Contains("Username") ? nameof(registerdUserDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }


            return null;
        }

        // login
        public async Task<UserDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(60))

                };
            }

            return null;
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
