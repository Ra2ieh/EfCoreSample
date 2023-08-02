namespace EfSample.Infrastructure.Services.Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails()
    {
        var response = new Result<CourseWithTeachersDetailsResponse>();
        var data = new CourseWithTeachersDetailsResponse();
        var result = await _unitOfWork.CourseRepository.GetCourseWithTeachersDetails();
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
}
