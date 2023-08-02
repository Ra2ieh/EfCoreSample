namespace EfSample.Infrastructure.Services.Course;
public class CourseWithTeachersDetailsResponse
{
    public CourseWithTeachersDetailsResponse()
    {
        Teachers = new List<Teacher>();
    }
    public int CourseId { get; set; }
    public string Title { get; set; } = String.Empty;
    public List<Teacher> Teachers { get; set; }
}
