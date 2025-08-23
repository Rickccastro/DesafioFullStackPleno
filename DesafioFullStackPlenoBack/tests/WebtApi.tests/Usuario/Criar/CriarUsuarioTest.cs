using CommonTestsUtilities.Requests.Usuario;
using Desafio.Exception;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Usuario.Criar;
public class CriarUsuarioTest : DesafioClassFixture
{
    private const string METHOD = "User";

    public CriarUsuarioTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
    }

    [Fact]
    public async Task Sucesso()
    {
        var request = CriarUsuarioRequestBuild.Build();

        var result = await RequestPost(METHOD, request);

        result.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        response.RootElement.GetProperty("nome").GetString().Should().Be(request.Nome);
        response.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Error_Nome_Vazio()
    {
        var request = CriarUsuarioRequestBuild.Build();
        request.Nome = string.Empty;

        var result = await RequestPost(requestUri: METHOD, request: request);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("NOME_VAZIO");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }
}