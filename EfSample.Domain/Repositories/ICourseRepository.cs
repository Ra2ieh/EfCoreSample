

namespace EfSample.Domain.Repositories;

public interface  ICourseRepository
{

    List<CourseWithTeachersDetail> GetCourseWithTeachersDetails();

}
