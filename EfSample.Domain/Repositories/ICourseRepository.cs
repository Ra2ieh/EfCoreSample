

namespace EfSample.Domain.Repositories;

public interface  ICourseRepository
{

    Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetailsEager();
    Task<List<CourseWithTeachersAndTagsDetail>> GetCourseWithTeachersAndTagsDetailsEager();

}
