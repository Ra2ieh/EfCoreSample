

namespace EfSample.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{

    private readonly CourseDbContext _dbContext;
    public CourseRepository(CourseDbContext courseDbContext)
    {
        _dbContext = courseDbContext;
    }
    #region Eager Loading
    public async Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetailsEager()
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
                    TeacherId = teacher.Teacher.TeacherId,
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

    public async Task<List<CourseWithTeachersAndTagsDetail>> GetCourseWithTeachersAndTagsDetailsEager()
    {
        var response = new List<CourseWithTeachersAndTagsDetail>();
        var result = _dbContext.Course
            .Include(e => e.CourseTeachers.OrderBy(e=>e.TeacherId)).ThenInclude(e => e.Teacher).Skip(1)
            .Include(e=>e.Tags).ThenInclude(e=>e.Tag).Take(2)
            .OrderBy(e=>e.StartDate)
            .ToListAsync();
        foreach (var course in result.Result)
        {
            var teachers = new List<Teacher>();
            var tags = new List<Tag>();
            foreach (var teacher in course.CourseTeachers)
            {
                teachers.Add(new Teacher
                {
                    FirstName = teacher.Teacher.FirstName,
                    LastName = teacher.Teacher.LastName,
                    TeacherId = teacher.Teacher.TeacherId,
                });
            }
            foreach (var tag in course.Tags)
            {
                tags.Add(new Tag
                {
                    TagId = tag.Tag.TagId,
                    Title  =tag.Tag.Title
                });
            }
            response.Add(new CourseWithTeachersAndTagsDetail
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Teachers = teachers,
                Tags= tags

            });
        }
        return response;
    }
    #endregion

}
