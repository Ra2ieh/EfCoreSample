

namespace ApiHelper;

public interface IServiceInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration appSettings, Assembly startupProjectAssembly);
}
