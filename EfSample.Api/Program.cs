namespace EfSample.Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        //builder.Services.AddDbContext<CourseDbContext>(options =>
        //{
        //    options.UseSqlServer(builder.Configuration.GetConnectionString("CourseDbConectionString"));
        //});
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCourseWithTeahcersDetailQueryHandler).Assembly));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CourseWithTeachersAndTagsDetailQueryHandler).Assembly));

        //builder.Services.AddMediatR(typeof(GetCourseWithTeahcersDetailQueryHandler).Assembly);
        builder.Services.InstallServicesInAssemblies(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        //
        app.Use(async (httpContext, next) =>
        {
            if(httpContext.Request.Method == HttpMethod.Get.ToString())
            {
                httpContext.Response.Headers.Add("Accept", "Razieh's Accept");
            }
            await next();
        });
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.Run();
    }
}
