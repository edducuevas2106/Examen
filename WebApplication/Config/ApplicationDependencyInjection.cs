using Interfaces.Repositorios;
using Interfaces.Servicios;
using Logs;
using Microsoft.EntityFrameworkCore;
using Repositorio;
using Repositorio.Configuration;
using Servicio;

namespace WebApplication.Config
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            return services;
        }
        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("localDb");
            services.AddDbContext<EntitiesModel>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);
            services.AddServices();
        }


        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<Logs.ILogger, WindowsEventLogger>();
            services.AddScoped<IFacturaRepositorio, FacturaRepositorio>();
            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<IDirectorioService, DirectorioService>();
            services.AddScoped<IVentaServicio, VentaServicio>();
        }

    }
}
public class DatabaseConfiguration
{
    public bool UseInMemoryDatabase { get; set; }
    public string localDb { get; set; }
}
