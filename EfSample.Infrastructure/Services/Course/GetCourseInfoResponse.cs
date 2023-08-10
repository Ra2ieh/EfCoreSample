

namespace EfSample.Infrastructure.Services.Course
{
    public class GetCourseInfoResponse
    {
        public GetCourseInfoResponse()
        {
            Items = new List<CourseDto>();
        }
        public List<CourseDto> Items { get; set; }
    }
}
