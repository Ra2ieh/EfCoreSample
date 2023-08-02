namespace EfSample.Infrastructure.Services.Course;

public interface ICourseService
{
    Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails();
}
