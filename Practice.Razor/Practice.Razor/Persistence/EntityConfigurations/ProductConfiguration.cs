using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Practice.Razor.Common;
using Practice.Razor.Domain.Entitities;

namespace Practice.Razor.Persistence.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Dealer)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.DealerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(DataGeneration.Products);
        }
    }
}
