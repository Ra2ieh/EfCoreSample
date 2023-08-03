namespace EfSample.Infrastructure.Services.Course;

public interface ICourseService
{
    Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetailsEager();
    Task<Result<CourseWithTeachersAndTagsDetailRsponse>> GetCourseWithTeachersAndTagsDetailsEager();
}
