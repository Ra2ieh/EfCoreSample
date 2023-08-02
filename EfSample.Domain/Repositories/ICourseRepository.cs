

namespace EfSample.Domain.Repositories;

public interface  ICourseRepository
{

    Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetails();

}
