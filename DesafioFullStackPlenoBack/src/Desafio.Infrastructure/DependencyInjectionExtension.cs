using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Infraestructure.DataAccess;
using Desafio.Infrastructure.DataAcess;
using Desafio.Infrastructure.DataAcess.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DesafioDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Connection"))
       .EnableSensitiveDataLogging()
       .EnableDetailedErrors()
       .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
        );
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

    }
}
