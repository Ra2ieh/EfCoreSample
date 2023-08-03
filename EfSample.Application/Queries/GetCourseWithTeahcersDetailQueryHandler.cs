

namespace EfSample.Application.Queries;

public class GetCourseWithTeahcersDetailQueryHandler : IRequestHandler<GetCourseWithTeahcersDetailQuery, Result<CourseWithTeachersDetailsResponse>>
{
    private readonly ICourseService _courseServices;
    public GetCourseWithTeahcersDetailQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }
    public Task<Result<CourseWithTeachersDetailsResponse>> Handle(GetCourseWithTeahcersDetailQuery request, CancellationToken cancellationToken)
    {
       return _courseServices.GetCourseWithTeachersDetails(request.LoadingType);

    }
}
