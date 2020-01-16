using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Identity;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Models;
using MRKT.Common.Application.Exceptions;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Enumarations.Application;
using MRKT.Common.Infrastructure.Extentions;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MRKT.Common.Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(ApplicationUser user, ApplicationUserType type, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.Name, user.UserName));
                await _userManager.AddClaimAsync(user, new Claim(JwtClaimTypes.GivenName, user.FirstName));
                await _userManager.AddClaimAsync(user, new Claim(IdentityServerConstants.StandardScopes.Email, user.Email));
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, type.ToString()));

                result = await _userManager.AddToRoleAsync(user, type.ToString());
            }

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if(user == null)
            {
                throw new NotFoundException(userId, typeof(ApplicationUser).Name);
            }

            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            return await Task.FromResult<bool>(_userManager.Users.Any(u => u.UserName == userName));
        }
    }
}
