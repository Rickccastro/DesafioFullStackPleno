using Desafio.Application.UseCase.Usuario.Atualizar;
using Desafio.Application.UseCase.Usuario.Cria;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Error;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[Authorize(Roles = nameof(Perfis.Administrador))]
[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(ResponseError), StatusCodes.Status403Forbidden)]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CriarUsuario([FromServices] ICriarUsuarioUseCase useCase, [FromBody] CriarUsuarioRequest request)
    {
        var nomeUsuario = await useCase.CriarUsuario(request);

        return Created(string.Empty,nomeUsuario);
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AtualizarUsuario([FromServices] IAtualizarUsuarioUseCase useCase, [FromBody] AtualizarUsuarioRequest request)
    {
        await useCase.AtualizarUsuario(request);

        return NoContent();
    }
}
