

namespace EfSample.Infrastructure.Services.Course;

public class CourseInfoWithTags:CourseInfo
{
    public CourseInfoWithTags()
    {
        Tags = new List<Tag>();
    }
    public List<Tag> Tags { get; set; }
}
