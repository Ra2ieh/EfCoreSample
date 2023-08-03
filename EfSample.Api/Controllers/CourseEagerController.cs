namespace EfSample.Api.Controllers;
[ApiController]
[Route("api/v1/Course/Eager/[action]")]
public class CourseEagerController : Controller
{
    private readonly IMediator _mediator;
    public CourseEagerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersDetail(GetCourseWithTeahcersDetailEagerQuery getCourseWithTeahcersDetailQuery)
    {
        var serviceResult = await _mediator.Send(getCourseWithTeahcersDetailQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseWithTeahcersAndTagsDetail()
    {
        GetCourseWithTeahcersAndTagsDetailEagerQuery getCourseWithTeahcersDetailQuery =new GetCourseWithTeahcersAndTagsDetailEagerQuery();
        var serviceResult = await _mediator.Send(getCourseWithTeahcersDetailQuery);
        if (serviceResult.HasError)
            return BadRequest(serviceResult.Error);

        return Ok(serviceResult.Data);
    }
}
