

namespace EfSample.Application.Queries;

public class SearchCourseQuery:IRequest<Result<SearchCourseResponse>>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string SearchText { get; set; }
}
