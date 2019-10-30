using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Infrastructure.Extenctions;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Common.Persistence.Context
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService,
            IDateTimeService dateTimeService) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Aggregate>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UpdateAddedCredentials(_dateTimeService.Now, _currentUserService.UserId);
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateModifiedCredentials(_dateTimeService.Now, _currentUserService.UserId);
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyAllConfigurations();
        }
    }
}
