using CommonTestsUtilities.Requests.Usuario;
using Desafio.Exception;
using Desafio.Exceptions;
using FluentAssertions;
using System.Globalization;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Usuario.Atualizar;
public class AtualizarUsuarioTest : DesafioClassFixture
{
    private const string METHOD = "Usuario";

    private readonly string _token;
    private readonly Guid _usuarioId;

    public AtualizarUsuarioTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _token = webApplicationFactory.Get_Usuario_Perfil_Administrador.GetToken();
        _usuarioId = webApplicationFactory.Get_Usuario_Perfil_Administrador.GetId();
    }

    [Fact]
    public async Task Sucesso()
    {
        var request = AtualizarUsuarioRequestBuild.Build();

        request.Id = _usuarioId;    

        var result = await RequestPut(METHOD, request, token: _token);

        result.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Error_Nome_Vazio()
    {
        var request = AtualizarUsuarioRequestBuild.Build();
        request.Nome = string.Empty;

        var response = await RequestPut(METHOD, request, token: _token);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        await using var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        var errors = responseData.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("NOME_VAZIO");

        errors.Should().HaveCount(1).And.Contain(c => c.GetString()!.Equals(expectedMessage));
    }
}