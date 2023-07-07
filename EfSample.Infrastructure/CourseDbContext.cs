

namespace EfSample.Infrastructure;

public class CourseDbContext:DbContext
{
    public DbSet<Course> Course { get; set; }
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Tag> Tag { get; set; }
    public DbSet<Discount> Discount { get; set; }
    public DbSet<Comment> Comment { get; set; }
    public DbSet<CourseTeachers> CourseTeachers { get; set; }

    #region constructor
    public CourseDbContext(DbContextOptions<CourseDbContext> options):base(options)
    {

    }
    #endregion
}
