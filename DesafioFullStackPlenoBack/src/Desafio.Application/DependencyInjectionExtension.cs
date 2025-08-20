using Desafio.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Desafio.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCase(services);
    }

    public static void AddUseCase(IServiceCollection services)
    {
    }
}