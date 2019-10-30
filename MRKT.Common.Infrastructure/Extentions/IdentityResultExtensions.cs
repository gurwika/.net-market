using Microsoft.AspNetCore.Identity;
using MRKT.Common.Application.Common.Models;
using System.Linq;

namespace MRKT.Common.Infrastructure.Extentions
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
