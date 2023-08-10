

namespace EfSample.Infrastructure.Services.Course;

public class SearchCourseRequest
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string SearchText { get; set; }
}
