namespace EfSample.Infrastructure.Services.Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
       _unitOfWork = unitOfWork;
    }
    public async Task<Result<List<CourseWithTeachersDetailsResponse>>> GetCourseWithTeachersDetails()
    {
        var response = new Result<List<CourseWithTeachersDetailsResponse>>();
        var data = new List<CourseWithTeachersDetailsResponse>();
        var result=await _unitOfWork.CourseRepository.GetCourseWithTeachersDetails();
        if (result is null)
        {
            response.Error.Code = "12";
            response.Error.Message = "یافت نشد";
            return response;
        };
        foreach (var item in result)
        {
            var course = new  CourseWithTeachersDetailsResponse
            {

                CourseId = item.CourseId,
                Title = item.Title,
                Teachers = item.Teachers,
            };
            data.Add(course);
        }
        response.Data = data;
        return response;
    }
}
