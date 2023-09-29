
namespace EfSample.Domain.EntityConfigurations;

public class DiscountEntityConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
       builder.Property(x => x.Title).HasMaxLength(500);
    }
}

