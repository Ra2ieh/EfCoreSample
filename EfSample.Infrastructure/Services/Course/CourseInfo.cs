

namespace EfSample.Infrastructure.Services.Course;

public class CourseInfo
{
    public CourseInfo()
    {
        Teachers = new List<Teacher>();
    }
    public int CourseId { get; set; }
    public string Title { get; set; } = String.Empty;
    public List<Teacher> Teachers { get; set; }
}
