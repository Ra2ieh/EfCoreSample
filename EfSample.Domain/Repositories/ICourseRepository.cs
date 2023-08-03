

namespace EfSample.Domain.Repositories;

public interface  ICourseRepository
{

    Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetailsEager();
    Task<List<CourseWithTeachersAndTagsDetail>> GetCourseWithTeachersAndTagsDetailsEager();
    Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetailsExplicit();
    Task<List<CourseWithTeachersAndTagsDetail>> GetCourseWithTeachersAndTagsDetailsExplicit();


}
