namespace EfSample.Api
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {

            // Add services to the container.
            builder.Services.AddMvc();
            builder.Services.AddApiVersioning();
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCourseWithTeahcersDetailQueryHandler).Assembly));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CourseWithTeachersAndTagsDetailQueryHandler).Assembly));

            //builder.Services.AddMediatR(typeof(GetCourseWithTeahcersDetailQueryHandler).Assembly);
            builder.Services.InstallServicesInAssemblies(builder.Configuration);
            return builder.Build();
        }
        public static WebApplication ConfigurePileLine(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //
            app.Map("/admin", myapp =>
            {
                myapp.UseMiddleware<ResponseDtoMiddleware>();


            }
            );
            app.Use(async (httpContext, next) =>
            {
                if (httpContext.Request.Method == HttpMethod.Get.ToString())
                {
                    httpContext.Response.Headers.Add("Accept", "Razieh's Accept");
                }
                await next();
            });
            // app.UseMiddleware<ResponseDtoMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            return app;
        }
    }
}
