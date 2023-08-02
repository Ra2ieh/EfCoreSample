

namespace EfSample.Api.Infrastructure;

public static class ServiceInstallerExtensions
{

        public static void InstallServicesInAssemblies(this IServiceCollection services, IConfiguration appSettings)
        {
            var startupProjectAssembly = AppDomain.CurrentDomain.GetAssemblies();

            var allTypes = startupProjectAssembly.SelectMany(a => a.GetTypes());

            var installers = allTypes
                .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(IServiceInstaller).IsAssignableFrom(c))
                .Select(Activator.CreateInstance).Cast<IServiceInstaller>().ToList();

            installers.ForEach(i => i.InstallServices(services, appSettings, Assembly.GetCallingAssembly()));
        }


    
}
