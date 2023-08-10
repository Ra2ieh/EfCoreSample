

namespace EfSample.Infrastructure.Services.Course;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<CourseWithTeachersDetailsResponse>> GetCourseWithTeachersDetails(LoadingTypes loadingTypes)
    {
        var response = new Result<CourseWithTeachersDetailsResponse>();
        var result =new List<CourseWithTeachersDetail>();
                switch (loadingTypes)
        {
            case LoadingTypes.EagerLoading:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersDetailsEager();
                break;
            case LoadingTypes.ExplicitLoading:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersDetailsExplicit();
                break;
            default:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersDetailsEager();
                break;
        }
        return CourseWithTeachers(result,response);
       
    }

    public async Task<Result<CourseWithTeachersAndTagsDetailRsponse>> GetCourseWithTeachersAndTagsDetails(LoadingTypes loadingTypes)
    {
        var response = new Result<CourseWithTeachersAndTagsDetailRsponse>();

        var result = new List<CourseWithTeachersAndTagsDetail>();
        switch (loadingTypes)
        {
            case LoadingTypes.EagerLoading:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersAndTagsDetailsEager();
                break;
            case LoadingTypes.ExplicitLoading:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersAndTagsDetailsExplicit();
                break;
            default:
                 result = await _unitOfWork.CourseRepository.GetCourseWithTeachersAndTagsDetailsEager();
                break;
        }
        return CourseWithTeachersAndTags(result, response);
    }
    public async Task<Result<GetCourseInfoResponse>> GetCourseShortInfo()
    {
        var response = new Result<GetCourseInfoResponse>();
        var data = new GetCourseInfoResponse();
        var result = new List<CourseDto>();
        var dbResult = await _unitOfWork.CourseRepository.GetCourseSelectLoading();
        if (dbResult != null)
        {
            foreach (var course in dbResult)
            {
                result.Add(new CourseDto
                {
                    CourseTitle = course.Tilte,
                    CourseId = course.Id
                });
            }
            response.Data = data;
            response.Data.Items = result;
            return response;
        }
        else
        {
            response.SetError(new CustomError
            {
                Code = "12",
                Message = "یافت نشد"
            });
            return response;
        }

    }


    private Result<CourseWithTeachersDetailsResponse> CourseWithTeachers(List<CourseWithTeachersDetail> req, Result<CourseWithTeachersDetailsResponse> res)
    {
        var data = new CourseWithTeachersDetailsResponse();
        if (req is null)
        {
            res.SetError(new CustomError
            {
                Code = "12",
                Message = "یافت نشد"
            });
            return res;
        };
        var courseInfo = new List<CourseInfo>();
        foreach (var item in req)
        {
            var course = new CourseInfo
            {

                CourseId = item.CourseId,
                Title = item.Title,
                Teachers = item.Teachers,
            };
            courseInfo.Add(course);
        }

        res.Data = data;
        res.Data.Items = courseInfo;
        return res;
    }


    private Result<CourseWithTeachersAndTagsDetailRsponse> CourseWithTeachersAndTags(List<CourseWithTeachersAndTagsDetail> result,Result<CourseWithTeachersAndTagsDetailRsponse> response)
    {
        var data = new CourseWithTeachersAndTagsDetailRsponse();
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
                Tags = item.Tags
            };
            courseInfo.Add(course);
        }

        response.Data = data;
        response.Data.Items = courseInfo;
        return response;
    }
}
