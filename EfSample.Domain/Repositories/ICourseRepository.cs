

namespace EfSample.Domain.Repositories;

public interface  ICourseRepository
{

    Task<List<CourseWithTeahcersDetail>> GetCourseWithTeachersDetails();

}
