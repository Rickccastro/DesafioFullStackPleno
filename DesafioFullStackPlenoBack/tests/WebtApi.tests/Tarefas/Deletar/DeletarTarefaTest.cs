using Desafio.Communication.Responses.Tarefa;
using Desafio.Domain.Entities;
using Desafio.Exceptions;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Tarefas.Deletar;
public class DeletarTarefaTest : DesafioClassFixture
{
    private const string METHOD = "Tarefas";

    private readonly string _token;
    private readonly Guid _tarefaId;
    public DeletarTarefaTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetToken();
        _tarefaId = webApplicationFactory.Get_Tarefa_Perfil_Usuario.GetId();
    }

    [Fact]
    public async Task Sucesso()
    {
        var result = await RequestDelete(requestUri: $"{METHOD}/{_tarefaId}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);

        result = await RequestGet(requestUri: $"{METHOD}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var content = await result.Content.ReadAsStringAsync();
        var tarefas = JsonConvert.DeserializeObject<List<TarefaResponse>>(content);

        tarefas.Should().NotContain(t => t.Id == _tarefaId);
    }

    [Fact]
    public async Task Error_Tarefa_Nao_Encontrada()
    {
        var tarefaId = Guid.NewGuid();

        var result = await RequestDelete(requestUri: $"{METHOD}/{tarefaId}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NotFound);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("TAREFA_NAO_ENCONTRADA");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage + "."));
    }
}