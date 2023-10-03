namespace EfSample.Infrastructure;

public class CourseDbContext:DbContext
{
    public DbSet<Course> Course { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<CourseTeachers> CourseTeachers { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<MyCourses> MyCourses { get; set; }
    public DbSet<Account> Account{ get; set; }
    public DbSet<CourseIncludingDiscount> CourseIncludingDiscount { get; set; }

    #region constructor
    public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options)
    {

    }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if(Database.IsSqlServer() || Database.IsRelational())
        {
            //do something
        }
        modelBuilder.HasDefaultSchema("dbt");
        //modelBuilder.Entity<Course>().Ignore(e=>e.Zones);
        modelBuilder.Ignore<Zone>();
        modelBuilder.ApplyConfiguration(new DiscountEntityConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        modelBuilder.Entity<CourseIncludingDiscount>().ToTable(nameof(CourseIncludingDiscount),"view");
        //one to one relationship configuration with fluent
        modelBuilder.Entity<Teacher>().HasOne(o=>o.Account)
                    .WithOne()
                    .HasForeignKey<Account>(o=>o.AccountId)
                    .OnDelete(DeleteBehavior.ClientCascade);
        // one to many relationship configuration with fluent
        modelBuilder.Entity<Course>().HasMany(o => o.Comments)
                                     .WithOne()
                                     .HasForeignKey(o => o.CourseId)
                                     .IsRequired()
                                     .HasPrincipalKey(e=>e.CourseSerie)
                                     .HasConstraintName("CourseINrelWithComment");
        modelBuilder.Entity<Course>(c =>
        {
            c.HasMany(o=>o.Tags)
             .WithMany(t=>t.Courses)
             .UsingEntity<CourseTag>(
                c=>c.HasOne(d=>d.Tag)
                .WithMany()
                .HasForeignKey(d=>d.TagId),
                t=>t.HasOne(d=>d.Course)
                .WithMany()
                .HasForeignKey(d=>d.TagId));
        });
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(250);
    }
}
