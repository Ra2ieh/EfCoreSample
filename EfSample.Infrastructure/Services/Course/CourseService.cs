namespace EfSample.Infrastructure.Services.Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetailsEager()
    {
        var response = new Result<CourseWithTeachersDetailsResponse>();
        var data = new CourseWithTeachersDetailsResponse();
        var result = await _unitOfWork.CourseRepository.GetCourseWithTeachersDetailsEager();
        if (result is null)
        {
            response.SetError(new CustomError
            {
                Code = "12",
                Message = "یافت نشد"
            });
            return response;
        };
        var courseInfo = new List<CourseInfo>();
        foreach (var item in result)
        {
            var course = new CourseInfo
            {

                CourseId = item.CourseId,
                Title = item.Title,
                Teachers = item.Teachers,
            };
            courseInfo.Add(course);
        }

        response.Data = data;
        response.Data.Items = courseInfo;
        return response;
    }

    public async Task<Result<CourseWithTeachersAndTagsDetailRsponse>> GetCourseWithTeachersAndTagsDetailsEager()
    {
        var response = new Result<CourseWithTeachersAndTagsDetailRsponse>();
        var data = new CourseWithTeachersAndTagsDetailRsponse();
        var result = await _unitOfWork.CourseRepository.GetCourseWithTeachersAndTagsDetailsEager();
        if (result is null)
        {
            response.SetError(new CustomError
            {
                Code = "12",
                Message = "یافت نشد"
            });
            return response;
        };
        var courseInfo = new List<CourseInfoWithTags>();
        foreach (var item in result)
        {
            var course = new CourseInfoWithTags
            {

                CourseId = item.CourseId,
                Title = item.Title,
                Teachers = item.Teachers,
                Tags=item.Tags
            };
            courseInfo.Add(course);
        }

        response.Data = data;
        response.Data.Items = courseInfo;
        return response;
    }
}
