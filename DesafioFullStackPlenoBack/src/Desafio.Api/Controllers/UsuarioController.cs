using Desafio.Application.UseCase.Usuario.Atualizar;
using Desafio.Application.UseCase.Usuario.Cria;
using Desafio.Application.UseCase.Usuario.Listar;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Error;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
[ProducesResponseType(typeof(ResponseError), StatusCodes.Status403Forbidden)]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
    [Authorize(Roles = nameof(Perfis.Administrador))]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CriarUsuario([FromServices] ICriarUsuarioUseCase useCase, [FromBody] CriarUsuarioRequest request)
    {
        var nomeUsuario = await useCase.CriarUsuario(request);

        return Created(string.Empty,nomeUsuario);
    }
    [HttpGet]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status200OK)]
    [Authorize(Roles = nameof(Perfis.Administrador) + "," + nameof(Perfis.Usuario))]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetUsuarios([FromServices] IListaUsuariosUseCase useCase)
    {
        var listaUsuarios = await useCase.ListarUsuarios();

        return Ok(listaUsuarios);
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(UsuarioResponse), StatusCodes.Status201Created)]
    [Authorize(Roles = nameof(Perfis.Administrador))]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AtualizarUsuario([FromServices] IAtualizarUsuarioUseCase useCase, [FromBody] AtualizarUsuarioRequest request)
    {
        await useCase.AtualizarUsuario(request);

        return NoContent();
    }
}
