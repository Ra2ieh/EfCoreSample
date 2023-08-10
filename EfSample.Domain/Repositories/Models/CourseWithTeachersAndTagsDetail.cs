

namespace EfSample.Domain.Repositories.Identities;

public class CourseWithTeachersAndTagsDetail: CourseWithTeachersDetail
{
    public CourseWithTeachersAndTagsDetail()
    {
        Tags = new List<Tag>();
    }
    public List<Tag> Tags { get; set; }
}
