using Desafio.Application.AutoMapper;
using Desafio.Application.UseCase.Login;
using Desafio.Application.UseCase.Tarefa.Atualizar;
using Desafio.Application.UseCase.Tarefa.Criar;
using Desafio.Application.UseCase.Tarefa.Deletar;
using Desafio.Application.UseCase.Tarefa.Listar;
using Desafio.Application.UseCase.Usuario.Atualizar;
using Desafio.Application.UseCase.Usuario.Cria;
using Desafio.Application.UseCase.Usuario.Listar;
using Microsoft.Extensions.DependencyInjection;


namespace Desafio.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCase(services);
        AddAutoMapper(services);
    }
    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    public static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<ICriarUsuarioUseCase, CriarUsuarioUseCase>();
        services.AddScoped<IAtualizarUsuarioUseCase, AtualizarUsuarioUseCase>();

        services.AddScoped<ICriarTarefaUseCase, CriarTarefaUseCase>();
        services.AddScoped<IDeletarTarefaUseCase, DeletarTarefaUseCase>();
        services.AddScoped<IAtualizarTarefaUseCase, AtualizarTarefaUseCase>();
        services.AddScoped<IListarTarefaUseCase, ListarTarefaUseCase>();
        services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>();
        services.AddScoped<IListaUsuariosUseCase, ListaUsuariosUseCase>();
    }
}