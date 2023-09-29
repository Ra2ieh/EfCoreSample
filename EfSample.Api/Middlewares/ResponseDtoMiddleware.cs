namespace EfSample.Api.Middlewares;

public class ResponseDtoMiddleware
{
    private RequestDelegate _next;

    public ResponseDtoMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {

        context.Response.Headers.Add("MyHeader",$"{context.Request.Method} header");
        await _next(context);
    }
}
