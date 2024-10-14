using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VeritcalSliceArch.Infrastructure.Persistence.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=OLGUNBEY\\SQLEXPRESS;Database=VSA;Trusted_Connection=True; TrustServerCertificate=True;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
