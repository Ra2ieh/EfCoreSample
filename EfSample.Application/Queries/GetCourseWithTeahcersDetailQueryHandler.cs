

namespace EfSample.Application.Queries;

public class GetCourseWithTeahcersDetailQueryHandler : IRequestHandler<GetCourseWithTeahcersDetailQuery, Result<List<CourseWithTeachersDetailsResponse>>>
{
    private readonly ICourseService _courseServices;
    public GetCourseWithTeahcersDetailQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }
    public Task<Result<List<CourseWithTeachersDetailsResponse>>> Handle(GetCourseWithTeahcersDetailQuery request, CancellationToken cancellationToken)
    {
       return _courseServices.GetCourseWithTeachersDetails();

    }
}
