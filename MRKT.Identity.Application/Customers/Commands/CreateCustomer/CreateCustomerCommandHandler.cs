using MediatR;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Common.Handlers;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Commands;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Entities.Identity;
using MRKT.Common.Domain.Enumarations.Application;
using MRKT.Common.Domain.Exceptions;
using MRKT.Identity.Application.System.Commands.SeedSampleData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Identity.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : CommandHandler, ICommandHandler<CreateCustomerCommand>
    {
        private readonly IUserManagerService _userManagerService;
        
        public CreateCustomerCommandHandler(IUserManagerService userManagerService, IApplicationDbContext context, IEventBus eventBus) : base (context, eventBus)
        {
            _userManagerService = userManagerService;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = new ApplicationUser(
                    request.Email,
                    request.FirstName,
                    request.LastName,
                    request.PersonalId
            );

            var userExist = await _userManagerService.UserExistsAsync(applicationUser.Email);

            if (userExist)
            {
                throw new DomainException("Customer exists");
            }

            var identityResult = await _userManagerService.CreateUserAsync(applicationUser, ApplicationUserType.Admin, request.Password);

            if(!identityResult.Result.Succeeded)
            {
                throw new DomainException(String.Join(", ", identityResult.Result.Errors));
            }

            var customer = new Customer(
                Guid.NewGuid(),
                request.gender,
                request.birthDate,
                applicationUser.Id
            );

            _context.Add(customer);

            await SaveAndPublish(customer, cancellationToken);

            return Unit.Value;
        }
    }
}
