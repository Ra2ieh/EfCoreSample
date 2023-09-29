



namespace EfSample.Domain.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(e=>e.UserName).IsRequired(true).IsUnicode(true).HasMaxLength(20);
        builder.Property(e=>e.FirstName).HasMaxLength(50);
        builder.Property(e=>e.LastName).HasMaxLength(50);
        builder.Property(e=>e.UserType).HasConversion<string>();
        //inline
        builder.Property(e=>e.Age).HasConversion(e=>e.ToString(),e=>int.Parse(e));
        builder.Property(e=>e.UserShipAge).HasConversion<IntoToStringConvertor>();
    }
}
