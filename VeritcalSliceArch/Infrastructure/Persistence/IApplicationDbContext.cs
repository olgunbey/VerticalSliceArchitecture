using Microsoft.EntityFrameworkCore;
using VeritcalSliceArch.Domain.Entities;

namespace VeritcalSliceArch.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
