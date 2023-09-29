
namespace EfSample.Domain.EntityConfigurations;

internal class CourseIncludingDiscountEntityConfiguration : IEntityTypeConfiguration<CourseIncludingDiscount>
{
    public void Configure(EntityTypeBuilder<CourseIncludingDiscount> builder)
    {
        builder.HasNoKey();
        builder.Property(e => e.CourseTitle).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.NewPrice).HasPrecision(14,2);
    }
}
