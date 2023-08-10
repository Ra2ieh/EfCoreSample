

namespace EfSample.Infrastructure.Services.Course;

public class SearchCourseResponse
{
    public SearchCourseResponse()
    {
        Items = new List<CourseDto>();
    }
    public List<CourseDto> Items { get; set; }
}
