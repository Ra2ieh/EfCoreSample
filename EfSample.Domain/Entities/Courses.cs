namespace EfSample.Domain.Entities;
[EntityTypeConfiguration(typeof(CourseEntityConfiguration))]

public  class Course
{
    private readonly ILazyLoader lazyLoader;

    public Course(ILazyLoader lazyLoader,string title)
    {
        Title ="title is :"+ title;
        this.lazyLoader = lazyLoader;
    }
    public int CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    private ICollection<CourseTeachers> _courseTeachers;
    public ICollection<CourseTeachers> CourseTeachers { get =>lazyLoader.Load(this,ref _courseTeachers); set=>_courseTeachers=value; }
    public ICollection<CourseTag> Tags { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public Discount Discount { get; set; }
    public string PersianStartDate { get;}
    public List<Zone> Zones { get;}
}
