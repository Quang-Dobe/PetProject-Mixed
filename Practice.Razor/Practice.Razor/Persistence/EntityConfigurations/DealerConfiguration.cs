using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Razor.Common;
using Practice.Razor.Domain.Entitities;

namespace Practice.Razor.Persistence.EntityConfigurations
{
    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Dealer)
                   .HasForeignKey(x => x.DealerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(DataGeneration.Dealers);
        }
    }
}
