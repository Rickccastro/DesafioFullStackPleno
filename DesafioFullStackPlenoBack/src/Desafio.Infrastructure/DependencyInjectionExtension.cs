using Desafio.Application.Security;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Infraestructure.DataAccess;
using Desafio.Infrastructure.DataAcess;
using Desafio.Infrastructure.DataAcess.Repositories.Entities;
using Desafio.Infrastructure.Services.Security;
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
        AddServices(services, configuration);
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
        services.AddScoped<ITarefaRepository, TarefaRepository>();
    }
    private static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        services.AddScoped<ILoggedUser, LoggedUser>();
    }
}
