using CommonTestsUtilities.Requests.Tarefa;
using Desafio.Exception;
using Desafio.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Tarefas.Atualizar;
public class AtualizarTarefaTest : DesafioClassFixture
{
    private const string METHOD = "Tarefas";
    

    private readonly string _token;
    private readonly Guid _tarefaId;
    public AtualizarTarefaTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetToken();
        _tarefaId = webApplicationFactory.Get_Tarefa_Perfil_Usuario.GetId();

    }

    [Fact]
    public async Task Sucesso()
    {
        var request = AtualizarTarefaRequestBuilder.Build();
        request.Id = _tarefaId;
        var result = await RequestPut(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Error_Title_Empty()
    {
        var request = AtualizarTarefaRequestBuilder.Build();
        request.Id = _tarefaId;
        request.Titulo = string.Empty;


        var result = await RequestPut(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("TITULO_OBRIGATORIO");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }

    [Fact]
    public async Task Error_Tarefa_Nao_Encontrada()
    {
        var request = AtualizarTarefaRequestBuilder.Build();

        request.Id = Guid.Parse("00000000-0000-0000-0000-000000000000");

        var result = await RequestPut(requestUri: METHOD, request: request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("TAREFA_NAO_ENCONTRADA");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage + "."));
    }
}