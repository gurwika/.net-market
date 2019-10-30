using Microsoft.AspNetCore.Identity;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Models;
using MRKT.Common.Application.Exceptions;
using MRKT.Common.Infrastructure.Extentions;
using System.Linq;
using System.Threading.Tasks;

namespace MRKT.Common.Infrastructure.Services
{
    public class UserRoleManagerService : IUserRoleManagerService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleManagerService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<(Result Result, string userRoleId)> CreateUserRoleAsync(string roleName)
        {
            var userRole = new IdentityRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpperInvariant(),
            };

            var result = await _roleManager.CreateAsync(userRole);

            return (result.ToApplicationResult(), userRole.Id);
        }

        public async Task<Result> DeleteUserAsync(string userRoleId)
        {
            var userRole = _roleManager.Roles.SingleOrDefault(u => u.Id == userRoleId);

            if (userRole == null)
            {
                throw new NotFoundException(userRoleId, typeof(IdentityRole).Name);
            }

            var result = await _roleManager.DeleteAsync(userRole);

            return result.ToApplicationResult();
        }
    }
}
