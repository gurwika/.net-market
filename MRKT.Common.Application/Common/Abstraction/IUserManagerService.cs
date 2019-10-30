using MRKT.Common.Application.Common.Models;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IUserManagerService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
