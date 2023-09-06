namespace EfSample.Api.Filters
{
    public class CheckTimeAttribute : ActionFilterAttribute
    {

        public static Stopwatch stopwatch;
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"******************* time :{stopwatch.ElapsedMilliseconds} ms");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }

    }
}
