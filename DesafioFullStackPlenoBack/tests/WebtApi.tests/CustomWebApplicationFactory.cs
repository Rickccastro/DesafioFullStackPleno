using CommonTestsUtilities.Entities;
using Desafio.Application.Security;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using Desafio.Infraestructure.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebtApi.test.Resources;

namespace WebtApi.tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public UsuarioHelper Get_Usuario_Perfil_Usuario { get; private set; } = default!;
    public UsuarioHelper Get_Usuario_Perfil_Administrador { get; private set; } = default!;
    public TarefasHelper Get_Tarefa_Perfil_Usuario { get; private set; } = default!;
    public TarefasHelper Get_Tarefa_Perfil_Administrador { get; private set; } = default!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<DesafioDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);
                });

                var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DesafioDbContext>();
                var accessTokenGenerator = scope.ServiceProvider.GetRequiredService<IAccessTokenGenerator>();

                StartDatabase(dbContext,accessTokenGenerator);
            });
    }

    private void StartDatabase(
        DesafioDbContext dbContext,
        IAccessTokenGenerator accessTokenGenerator)
    {
        var usuarioPerfilUsuario = AddUsuarioPerfil(dbContext, accessTokenGenerator);
        var tarefaPerfilUsuario = AddTarefasUsuario(dbContext, usuarioPerfilUsuario);
        Get_Tarefa_Perfil_Usuario = new TarefasHelper(tarefaPerfilUsuario);

        var usuarioAdmin = AddUsuarioPerfilAdmnistrador(dbContext,  accessTokenGenerator);
        var tarefasAdmin = AddTarefasUsuario(dbContext, usuarioAdmin);
        Get_Tarefa_Perfil_Administrador = new TarefasHelper(tarefasAdmin);

        dbContext.SaveChanges();
    }

    private Usuario AddUsuarioPerfil(
        DesafioDbContext dbContext,
        IAccessTokenGenerator accessTokenGenerator)
    {
        var user = UsuarioBuilder.Build();

        dbContext.Usuarios.Add(user);

        var token = accessTokenGenerator.Generate(user);

        Get_Usuario_Perfil_Usuario = new UsuarioHelper(user,token);

        return user;
    }

    private Usuario AddUsuarioPerfilAdmnistrador(
        DesafioDbContext dbContext,
        IAccessTokenGenerator accessTokenGenerator)
    {
        var user = UsuarioBuilder.Build(Perfis.Administrador);
        //user.Id = 2;

        dbContext.Usuarios.Add(user);

        var token = accessTokenGenerator.Generate(user);

        Get_Usuario_Perfil_Administrador = new UsuarioHelper(user, token);

        return user;
    }

    private Tarefa AddTarefasUsuario(DesafioDbContext dbContext, Usuario user)
    {
        var expense = TarefaBuilder.Build(user);


        dbContext.Tarefas.Add(expense);

        return expense;
    }
}
