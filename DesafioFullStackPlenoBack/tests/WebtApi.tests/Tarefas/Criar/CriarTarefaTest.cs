using CommonTestsUtilities.Requests.Tarefa;
using Desafio.Exception;
using Desafio.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Tarefas.Criar;
public class CriarTarefaTest : DesafioClassFixture
{
    private const string METHOD = "Tarefas";

    private readonly string _token;

    public CriarTarefaTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetToken();
    }

    [Fact]
    public async Task Sucesso()
    {
        var request = CriarTarefaRequestBuilder.Build();

        var result = await RequestPost(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        response.RootElement.GetProperty("titulo").GetString().Should().Be(request.Titulo);
    }

    [Fact]
    public async Task Error_Titulo_Vazio()
    {
        var request = CriarTarefaRequestBuilder.Build();
        request.Titulo = string.Empty;

        var result = await RequestPost(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("TITULO_OBRIGATORIO");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }
}