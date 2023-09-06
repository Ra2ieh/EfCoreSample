namespace EfSample.Api.Filters
{
    public class CheckTimeAttribute : Attribute, IActionFilter
    {

        public static Stopwatch stopwatch;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"******************* time :{stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch = Stopwatch.StartNew();
        }

    }
}
