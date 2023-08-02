namespace EfSample.Api.Controllers;
[ApiController]
[Route("api/v1/Course/[action]")]
public class CourseController : Controller
{
    private readonly IMediator _mediator;
    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersDetail(GetCourseWithTeahcersDetailQuery getCourseWithTeahcersDetailQuery)
    {
        var serviceResult = await _mediator.Send(getCourseWithTeahcersDetailQuery);
        if (serviceResult.HasError())
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }
}
