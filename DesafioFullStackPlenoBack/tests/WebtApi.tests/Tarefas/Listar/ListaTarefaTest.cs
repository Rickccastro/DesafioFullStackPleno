using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Tarefas.Listar;
public class ListaTarefaTest : DesafioClassFixture
{
    private const string METHOD = "Tarefas";

    private readonly string _token;
    public ListaTarefaTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetToken();
    }

    [Fact]
    public async Task Sucesso()
    {
        var result = await RequestGet(requestUri: $"{METHOD}", token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.OK);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var tarefas = response.RootElement.EnumerateArray().ToList();

        tarefas.Should().NotBeNullOrEmpty();
    }
}