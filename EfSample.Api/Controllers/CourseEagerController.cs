
namespace EfSample.Api.Controllers;
[ApiController]
[Route("api/v1/Course/[action]")]
public class CourseEagerController : Controller
{
    private readonly IMediator _mediator;
    public CourseEagerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersDetail([FromQuery] LoadingTypes loadingTypes)
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

    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersAndTagsDetail([FromQuery]LoadingTypes loadingTypes)
    {
        var getCourseWithTeahcersDetailQuery =new GetCourseWithTeahcersAndTagsDetailQuery
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
}
