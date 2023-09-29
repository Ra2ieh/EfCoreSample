namespace EfSample.Domain.EntityConfigurations;

public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(e => e.Title).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Price).HasPrecision(18, 2).IsRequired(true);
        builder.HasIndex(e => e.Title);
    }
}
