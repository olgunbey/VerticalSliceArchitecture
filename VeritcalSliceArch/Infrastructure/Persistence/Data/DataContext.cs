using Microsoft.EntityFrameworkCore;
using VeritcalSliceArch.Domain.Entities;

namespace VeritcalSliceArch.Infrastructure.Persistence.Data
{
    public class DataContext : DbContext, IApplicationDbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions):base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
