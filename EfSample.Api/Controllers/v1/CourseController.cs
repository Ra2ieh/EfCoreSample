
namespace EfSample.Api.Controllers;
[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/Course/[action]")]
public class CourseController : Controller
{
    private readonly IMediator _mediator;
    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [CheckTime]
    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersDetail( LoadingTypes loadingTypes)
    {
        var getCourseWithTeahcersDetailQuery = new GetCourseWithTeahcersDetailQuery
        {
            LoadingType = loadingTypes,
        };
        var serviceResult = await _mediator.Send(getCourseWithTeahcersDetailQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }
    [CheckTime]
    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersAndTagsDetail( LoadingTypes loadingTypes)
    {
        var getCourseWithTeahcersDetailQuery = new GetCourseWithTeahcersAndTagsDetailQuery
        {
            LoadingType = loadingTypes,
        };
        var serviceResult = await _mediator.Send(getCourseWithTeahcersDetailQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseInfoSelectLoading()
    {
        var getCourseInfoQuery = new GetCourseInfoQuery();

        var serviceResult = await _mediator.Send(getCourseInfoQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }
    [HttpPost]
    public async Task<IActionResult> SearchCourse(SearchCourseQuery searchCourseQuery)
    {
        var serviceResult = await _mediator.Send(searchCourseQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }

}
