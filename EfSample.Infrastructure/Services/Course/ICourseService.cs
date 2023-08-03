namespace EfSample.Infrastructure.Services.Course;

public interface ICourseService
{
    Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails(LoadingTypes loadingTypes);
    Task<Result<CourseWithTeachersAndTagsDetailRsponse>> GetCourseWithTeachersAndTagsDetails(LoadingTypes loadingTypes);

}
