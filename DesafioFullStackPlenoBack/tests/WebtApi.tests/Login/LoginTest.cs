using CommonTestsUtilities.Requests;
using Desafio.Communication.Requests.Login;
using Desafio.Exception;
using Desafio.Exceptions;
using FluentAssertions;
using System.Net;
using System.Text.Json;
using WebtApi.tests;

namespace WebtApi.test.Login;
public class LoginTest : DesafioClassFixture
{
    private const string METHOD = "/Login";

    private readonly string _email;
    private readonly string _nome;
    private readonly string _senha;
    public LoginTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
    {
        _email = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetEmail();
        _senha = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetSenha();
        _nome = webApplicationFactory.Get_Usuario_Perfil_Usuario.GetNome();
    }

    [Fact]
    public async Task Success()
    {
        var request = new LoginUsuarioRequest
        {
            Email = _email,
            Senha = _senha
        };

        var response = await RequestPost(requestUri: METHOD, request: request);

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        responseData.RootElement.GetProperty("nome").GetString().Should().Be(_nome);
        responseData.RootElement.GetProperty("token").GetString().Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Error_Login_Invalid()
    {
        var request = LoginUsuarioRequestBuilder.Build();

        var response = await RequestPost(requestUri: METHOD, request: request);

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

        var responseBody = await response.Content.ReadAsStreamAsync();

        var responseData = await JsonDocument.ParseAsync(responseBody);

        var errors = responseData.RootElement.GetProperty("errorMessages").EnumerateArray();

        var expectedMessage = ResourceErrorMessages.ResourceManager.GetString("EMAIL_OU_SENHA_INVALIDO");

        errors.Should().HaveCount(1).And.Contain(c => c.GetString()!.Equals(expectedMessage));
    }
}
