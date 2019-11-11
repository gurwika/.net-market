using MRKT.Common.Application.Common.Models;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Enumarations.Application;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IUserManagerService
    {
        Task<bool> UserExistsAsync(string userName);
        Task<(Result Result, string UserId)> CreateUserAsync(ApplicationUser user, ApplicationUserType type, string password);
        Task<Result> DeleteUserAsync(string userId);
    }
}
