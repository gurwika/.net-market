using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.ValueObjects;
using MRKT.Common.Persistence.Context;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MRKT.Common.Persistence.Test.Context
{
    public class ApplicationDbContextTests
    {
        private readonly string _userId;
        private readonly DateTime _dateTime;

        private readonly Mock<IDateTimeService> _dateTimeMock;
        private readonly Mock<ICurrentUserService> _currentUserServiceMock;

        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IOptions<OperationalStoreOptions> _operationalStoreOptions;
        public ApplicationDbContextTests()
        {
            _dateTime = new DateTime(3001, 1, 1);
            _dateTimeMock = new Mock<IDateTimeService>();
            _dateTimeMock.Setup(m => m.Now).Returns(_dateTime);

            _userId = "00000000-0000-0000-0000-000000000000";
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _currentUserServiceMock.Setup(m => m.UserId).Returns(_userId);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _operationalStoreOptions = Options.Create(new OperationalStoreOptions());
            _applicationDbContext = new ApplicationDbContext(options, _operationalStoreOptions, _currentUserServiceMock.Object, _dateTimeMock.Object);
        }

        [Fact]
        public async Task SaveChangesAsyncShouldSetCreatedProperties()
        {
            var address = new Address(
                  Guid.NewGuid(),
                  "Giorgi",
                  "Gurtsishvili",
                  "11 Khevdzmari street",
                  "Temqa",
                  "Tbilisi",
                  "Tbilisi",
                  "0153",
                  (PhoneNumber)"577-348094"
            );

            _applicationDbContext.Set<Address>().Add(address);
            await _applicationDbContext.SaveChangesAsync();

            Assert.Equal(_dateTime, address.CreatedAt);
            Assert.Equal(_userId, address.LastModifiedBy);
        }
    }
}
