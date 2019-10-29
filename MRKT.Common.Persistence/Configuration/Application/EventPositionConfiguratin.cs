using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MRKT.Common.Domain.Entities.Application;

namespace MRKT.Common.Persistence.Configuration.Application
{
    public class EventPositionConfiguratin : IEntityTypeConfiguration<EventPosition>
    {
        public void Configure(EntityTypeBuilder<EventPosition> builder)
        {
        }
    }
}
