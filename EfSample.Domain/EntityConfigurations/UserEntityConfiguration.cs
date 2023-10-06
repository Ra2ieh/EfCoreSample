



namespace EfSample.Domain.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c=>new {c.UserId,c.UserName});
        builder.Property(e=>e.UserName).IsRequired(true).IsUnicode(true).HasMaxLength(20);
        builder.Property(e=>e.FirstName).HasMaxLength(50);
        builder.Property(e=>e.LastName).HasMaxLength(50);
        builder.Property(e => e.FirstName).HasMaxLength(102);
        builder.Property(e=>e.UserType).HasConversion<string>().HasMaxLength(10);
        //inline
        builder.Property(e=>e.Age).HasConversion(e=>e.ToString(),e=>int.Parse(e)).HasMaxLength(2);
        builder.Property(e=>e.UserShipAge).HasConversion<IntoToStringConvertor>().HasMaxLength(2);
        builder.Property(c => c.LastName).HasField("_lastNameField");

    }
}
