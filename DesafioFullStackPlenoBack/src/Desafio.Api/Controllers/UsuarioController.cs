using Desafio.Application.UseCase.Usuario.Cria;
using Desafio.Communication.Requests.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [Route("cria-usuario")]
    [HttpPost]
    public async Task<ActionResult> Create([FromServices] ICriaUsuarioUseCase useCase, [FromBody] UsuarioRequest request)
    {
        var resultCreateCheckoutUseCase = await useCase.CreateUser(request);

        return Ok(resultCreateCheckoutUseCase);
    }
}
