using MediatR;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Commands;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Enumarations.Application;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.System.Commands.SeedSampleData
{
    public class SeedSampleDataCommandHandler : ICommandHandler<SeedSampleDataCommand>
    {
        private readonly IUserManagerService _userManagerService;
        private readonly IUserRoleManagerService _userRoleManagerService;

        public SeedSampleDataCommandHandler(IUserManagerService userManagerService, IUserRoleManagerService userRoleManagerService)
        {
            _userManagerService = userManagerService;
            _userRoleManagerService = userRoleManagerService;
        }
        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var names = Enum.GetNames(typeof(ApplicationUserType));

            foreach (var roleName in names)
            {
                var roleExist = await _userRoleManagerService.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await _userRoleManagerService.CreateUserRoleAsync(roleName);
                }
            }

            var entity = new ApplicationUser(
                    "demouser@demo",
                    "Demo",
                    "Spa",
                    "1234567890"
            );

            var userExist = await _userManagerService.UserExistsAsync(entity.Email);
            if (!userExist)
            {
                await _userManagerService.CreateUserAsync(entity, ApplicationUserType.Admin, "Pass@word1");
            }

            return Unit.Value;
        }
    }
}
