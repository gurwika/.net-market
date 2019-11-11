using MediatR;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Enumarations.Application;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUserRoleManagerService _userRoleManagerService;
        private static string[] roleNames = { "Admin", "Seller", "Editor", "Reporter" };

        public SeedSampleDataCommandHandler(IUserManagerService userManagerService, IUserRoleManagerService userRoleManagerService)
        {
            _userManagerService = userManagerService;
            _userRoleManagerService = userRoleManagerService;
        }
        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await _userRoleManagerService.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await _userRoleManagerService.CreateUserRoleAsync(roleName);
                }
            }

            var userExist = await _userManagerService.UserExistsAsync("demouser@demo");
            if (!userExist)
            {
                await _userManagerService.CreateUserAsync("demouser@demo", "Pass@word1", ApplicationUserType.Admin);
            }

            return Unit.Value;
        }
    }
}
