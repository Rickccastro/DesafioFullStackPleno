using Desafio.Application.UseCase.Login;
using Desafio.Communication.Requests.Login;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    [Route("login-usuario")]
    [HttpPost]
    public async Task<IActionResult> LoginUsuario([FromServices] ILoginUsuarioUseCase useCase, [FromBody] LoginUsuarioRequest request)
    {
        var result = await useCase.LoginUsuario(request);

        return Ok(result);
    }
}
