

namespace EfSample.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{

    private readonly CourseDbContext _dbContext;
    public CourseRepository(CourseDbContext courseDbContext)
    {
        _dbContext = courseDbContext;
    }
    //EAGER LOADING
    public async Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetails()
    {
        var response = new List<CourseWithTeachersDetail>();
        var result = _dbContext.Course.Include(e => e.CourseTeachers).ThenInclude(e => e.Teacher).ToListAsync();
        foreach (var course in result.Result)
        {
            var teachers = new List<Teacher>();
            foreach (var teacher in course.CourseTeachers)
            {
                teachers.Add(new Teacher
                {
                    FirstName = teacher.Teacher.FirstName,
                    LastName = teacher.Teacher.LastName,
                });
            }
            response.Add(new CourseWithTeachersDetail
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Teachers = teachers,

            });
        }
        return response;
    }
}
