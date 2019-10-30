using MRKT.Common.Application.Common.Models;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IUserRoleManagerService
    {
        Task<(Result Result, string userRoleId)> CreateUserRoleAsync(string roleName);

        Task<Result> DeleteUserAsync(string userRoleId);
    }
}
