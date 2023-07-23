namespace EfSample.Domain.Services.Course;

public interface ICourseServices
{
    Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails();
}
