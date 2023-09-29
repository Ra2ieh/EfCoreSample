

namespace EfSample.Application.Queries;

public class GetCourseInfoQueryHandler : IRequestHandler<GetCourseInfoQuery, Result<GetCourseInfoResponse>>
{
    private readonly ICourseService _courseServices;
    public GetCourseInfoQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }
    public Task<Result<GetCourseInfoResponse>> Handle(GetCourseInfoQuery request, CancellationToken cancellationToken)
    {
        return _courseServices.GetCourseShortInfo();
    }
}
