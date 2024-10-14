using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeritcalSliceArch.Domain.Entities;

namespace VeritcalSliceArch.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(y => y.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(y => y.CategoryID);
        }
    }
}
