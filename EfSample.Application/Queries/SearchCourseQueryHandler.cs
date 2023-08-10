namespace EfSample.Application.Queries;

public class SearchCourseQueryHandler : IRequestHandler<SearchCourseQuery, Result<SearchCourseResponse>>
{
    private readonly ICourseService _courseServices;
    public SearchCourseQueryHandler(ICourseService courseServices)
    {
        _courseServices = courseServices;
    }
    public Task<Result<SearchCourseResponse>> Handle(SearchCourseQuery request, CancellationToken cancellationToken)
    {
        var searchRequest= new SearchCourseRequest
    {
        PageSize=request.PageSize,
        PageNumber=request.PageNumber,
        SearchText=request.SearchText,
    };
        return _courseServices.SearchCourse(searchRequest);
    }
}
