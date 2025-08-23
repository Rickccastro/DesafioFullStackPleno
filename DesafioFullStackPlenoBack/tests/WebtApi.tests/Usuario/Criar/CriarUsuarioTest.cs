using CommonTestsUtilities.Requests.Usuario;
using Desafio.Exception;
using Desafio.Exceptions;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Usuario.Criar;
public class CriarUsuarioTest : DesafioClassFixture
{
    private const string METHOD = "Usuario";

    private readonly string _token;

    public CriarUsuarioTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Administrador.GetToken();

    }

    [Fact]
    public async Task Sucesso()
    {
        var request = CriarUsuarioRequestBuild.Build();

        var result = await RequestPost(METHOD, request, _token);

        result.StatusCode.Should().Be(HttpStatusCode.Created);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        response.RootElement.GetProperty("nome").GetString().Should().Be(request.Nome);
    }

    [Fact]
    public async Task Error_Nome_Vazio()
    {
        var request = CriarUsuarioRequestBuild.Build();
        request.Nome = string.Empty;

        var result = await RequestPost(requestUri: METHOD, request: request,_token);

        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var body = await result.Content.ReadAsStreamAsync();

        var response = await JsonDocument.ParseAsync(body);

        var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("NOME_VAZIO");

        errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedMessage));
    }
}