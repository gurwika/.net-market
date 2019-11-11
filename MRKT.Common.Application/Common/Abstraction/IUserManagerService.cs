using MRKT.Common.Application.Common.Models;
using MRKT.Common.Domain.Enumarations.Application;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IUserManagerService
    {
        Task<bool> UserExistsAsync(string userName);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, ApplicationUserType type);
        Task<Result> DeleteUserAsync(string userId);
    }
}
