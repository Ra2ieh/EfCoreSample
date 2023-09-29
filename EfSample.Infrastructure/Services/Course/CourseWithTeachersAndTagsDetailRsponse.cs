

namespace EfSample.Infrastructure.Services.Course;

public class CourseWithTeachersAndTagsDetailRsponse
{
    public CourseWithTeachersAndTagsDetailRsponse()
    {
        Items = new List<CourseInfoWithTags>();
    }
    public List<CourseInfoWithTags> Items { get; set; }
}
