using Desafio.Application.UseCase.Usuario.Atualizar;
using Desafio.Application.UseCase.Usuario.Cria;
using Desafio.Communication.Requests.Usuario;
using Desafio.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[Authorize(Roles = nameof(Perfis.Administrador))]
[ApiController]
public class UsuarioController : ControllerBase
{
    [Route("criar-usuario")]
    [HttpPost]
    public async Task<ActionResult> CriarUsuario([FromServices] ICriarUsuarioUseCase useCase, [FromBody] CriarUsuarioRequest request)
    {
        var nomeUsuario = await useCase.CriarUsuario(request);

        return Ok(nomeUsuario);
    }
    [Route("atualizar-usuario")]
    [Authorize]
    [HttpPut]
    public async Task<ActionResult> AtualizarUsuario([FromServices] IAtualizarUsuarioUseCase useCase, [FromBody] AtualizarUsuarioRequest request)
    {
        var nomeUsuario = await useCase.AtualizarUsuario(request);

        return Ok(nomeUsuario);
    }
}
