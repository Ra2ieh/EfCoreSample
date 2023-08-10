namespace EfSample.Domain.Repositories.Models;

public class SearchCourseFilters
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public string SearchText { get; set; }
}
