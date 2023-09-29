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
        //query with shadow property
        var result =await _dbContext.Course.Where(c=>EF.Property<bool>(c,"IsDeleted")==false).Include(e => e.CourseTeachers).ThenInclude(e => e.Teacher).ToListAsync();
        foreach (var course in result)
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
    {   //using take and skip for pagination
        var response = new List<CourseWithTeachersAndTagsDetail>();
        var result =await _dbContext.Course
            .Include(e => e.CourseTeachers.OrderBy(e => e.TeacherId)).ThenInclude(e => e.Teacher).Skip(1)
            .Include(e => e.Tags).ThenInclude(e => e.Tag).Take(2)
            .OrderBy(e => e.StartDate)
            .ToListAsync();
        foreach (var course in result)
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
                    Title = tag.Tag.Title
                });
            }
            response.Add(new CourseWithTeachersAndTagsDetail
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Teachers = teachers,
                Tags = tags

            });
        }
        return response;
    }
    #endregion
    #region Explicit Loading
    public async Task<List<CourseWithTeachersDetail>> GetCourseWithTeachersDetailsExplicit()
    {
        var response = new List<CourseWithTeachersDetail>();
        var result =await _dbContext.Course.ToListAsync();
        foreach (var course in result)
        {
             _dbContext.Entry(course).Collection(c=>c.CourseTeachers).Load();
            var teachers = new List<Teacher>();
            foreach (var courseTeacher in course.CourseTeachers)
            {
                _dbContext.Entry(courseTeacher).Reference(c => c.Teacher).Load();
                teachers.Add(new Teacher
                {
                    FirstName = courseTeacher.Teacher.FirstName,
                    LastName = courseTeacher.Teacher.LastName,
                    TeacherId = courseTeacher.Teacher.TeacherId,
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

    public async Task<List<CourseWithTeachersAndTagsDetail>> GetCourseWithTeachersAndTagsDetailsExplicit()
    {
        var response = new List<CourseWithTeachersAndTagsDetail>();
        var result = _dbContext.Course.ToList();
        foreach (var course in result)
        {
            await _dbContext.Entry(course).Collection(e => e.CourseTeachers).LoadAsync();
            await _dbContext.Entry(course).Collection(e => e.Tags).LoadAsync();
            var teachers = new List<Teacher>();
            var tags = new List<Tag>();
            foreach (var courseTeacher in course.CourseTeachers)
            {
                await _dbContext.Entry(courseTeacher).Reference(e => e.Teacher).LoadAsync();
                teachers.Add(new Teacher
                {
                    FirstName = courseTeacher.Teacher.FirstName,
                    LastName = courseTeacher.Teacher.LastName,
                    TeacherId = courseTeacher.Teacher.TeacherId,
                });
            }
            foreach (var courseTag in course.Tags)
            {
                await _dbContext.Entry(courseTag).Reference(e => e.Tag).LoadAsync();
                tags.Add(new Tag
                {
                    TagId = courseTag.Tag.TagId,
                    Title = courseTag.Tag.Title
                });
            }
            response.Add(new CourseWithTeachersAndTagsDetail
            {
                CourseId = course.CourseId,
                Title = course.Title,
                Teachers = teachers,
                Tags = tags

            });
        }
        return response;
    }
    #endregion
    #region Select Loading
    public async Task<List<CourseShortInfo>> GetCourseSelectLoading()
    {
        var result = await _dbContext.Course.Select(e => new CourseShortInfo
        {
            Id = e.CourseId,
            Tilte = e.Title
        }).ToListAsync();
        return result;
    }

    public async Task<List<CourseShortInfo>> GetCourseWithFilter(SearchCourseFilters courseFilters)
    {
        var result = await _dbContext.Course.Select(e => new CourseShortInfo
        {
            Id = e.CourseId,
            Tilte = e.Title
        }).Where(c=> EF.Functions.Like(c.Tilte,$"%{courseFilters.SearchText}%")).Skip((courseFilters.PageNumber-1)* courseFilters.PageSize).Take(courseFilters.PageSize).ToListAsync();
        
        return result;
    }
    #endregion


}
