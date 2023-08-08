namespace EfSample.Infrastructure;

public class InfrastructureServiceInstaller:IServiceInstaller
{
 public void InstallServices(IServiceCollection services, IConfiguration appSettings, Assembly startupProjectAssembly)
    {
        var optionBuilder=new DbContextOptionsBuilder();
        optionBuilder.LogTo(Console.WriteLine);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddDbContext<CourseDbContext>(options =>
        options.UseSqlServer(appSettings.GetConnectionString("CourseDbConectionString"))
        
        );
       
        //var appConfig = appSettings.GetSection(nameof(AppConfig)).Get<AppConfig>();
        //services.AddHttpClientByConfig(appConfig.HttpClientConfigs.IranSign);
    }
}
