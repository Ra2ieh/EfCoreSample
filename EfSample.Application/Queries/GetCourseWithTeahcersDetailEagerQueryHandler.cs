

namespace EfSample.Application.Queries;

public class GetCourseWithTeahcersDetailEagerQueryHandler : IRequestHandler<GetCourseWithTeahcersDetailEagerQuery, Result<CourseWithTeachersDetailsResponse>>
{
    private readonly ICourseService _courseServices;
    public GetCourseWithTeahcersDetailEagerQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }
    public Task<Result<CourseWithTeachersDetailsResponse>> Handle(GetCourseWithTeahcersDetailEagerQuery request, CancellationToken cancellationToken)
    {
       return _courseServices.GetCourseWithTeachersDetailsEager();

    }
}
