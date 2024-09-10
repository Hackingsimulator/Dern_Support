using ErdAndEF.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace ErdAndEF.Repositories.Interfaces
{
    public interface IUser
    {

        // Add register
        public Task<UserDto> Register(RegisterdUserDto registerdUserDto, ModelStateDictionary modelState);


        // Add login 
        public Task<UserDto> UserAuthentication(string username, string password);


        // add user profile 
        public Task<UserDto> userProfile(ClaimsPrincipal claimsPrincipal);
    }
}
