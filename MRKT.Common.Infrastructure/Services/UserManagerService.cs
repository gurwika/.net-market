using Microsoft.AspNetCore.Identity;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Models;
using MRKT.Common.Application.Exceptions;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Infrastructure.Extentions;
using System.Linq;
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
    }
}
