using EfSample.Domain.Repositories.Identities;

namespace EfSample.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{

    private readonly CourseDbContext _dbContext;
    public CourseRepository(CourseDbContext courseDbContext)
    {
        _dbContext = courseDbContext;
    }
    public Task<List<CourseWithTeahcersDetail>> GetCourseWithTeachersDetails()
    {
        var response=new List<CourseWithTeahcersDetail>();
        var result=_dbContext.Course.Include(e=>e.CourseTeachers).ThenInclude(e=>e.Teacher).ToList();
        foreach (var item in result)
        {
            response.Add(new CourseWithTeahcersDetail
            {
                CourseId = item.CourseId,
                Title = item.Title
              
            });
        }
    }
}
