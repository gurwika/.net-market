using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Context.Abstraction
{
    public interface IApplicationDbContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        public EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;
    }
}
