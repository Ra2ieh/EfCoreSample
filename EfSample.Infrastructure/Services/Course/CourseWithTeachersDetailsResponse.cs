namespace EfSample.Infrastructure.Services.Course;
public class CourseWithTeachersDetailsResponse
{
    public CourseWithTeachersDetailsResponse()
    {
        Items = new List<CourseInfo>();
    }
    public List<CourseInfo> Items { get; set; }
}
