using ApiHelper;
using EfSample.Domain.Services.Course;

namespace EfSample.Infrastructure.Services;

public class CourseServices : ICourseServices
{
    private readonly ICourseRepository _courseRepository;
    public CourseServices(ICourseRepository courseRepository)
    {
        _courseRepository
    }
    public Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails()
    {
        throw new NotImplementedException();
    }
}
