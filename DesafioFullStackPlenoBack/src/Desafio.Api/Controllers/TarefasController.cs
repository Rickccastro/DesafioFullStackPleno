using Desafio.Application.UseCase.Tarefa.Atualizar;
using Desafio.Application.UseCase.Tarefa.Criar;
using Desafio.Application.UseCase.Tarefa.Deletar;
using Desafio.Application.UseCase.Tarefa.Listar;
using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Responses.Error;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[Authorize(Roles = $"{nameof(Perfis.Administrador)},{nameof(Perfis.Usuario)}")]
[ProducesResponseType(typeof(ResponseError), StatusCodes.Status401Unauthorized)]
[ApiController]
public class TarefasController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(TarefaResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CriarTarefa([FromServices] ICriarTarefaUseCase useCase, [FromBody] CriarTarefaRequest request)
    {
        var tarefa = await useCase.CriarTarefa(request);

        return Created(string.Empty,tarefa);
    }

    [HttpGet]
    [ProducesResponseType(typeof(TarefaListagemResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> ListaTarefa([FromServices] IListarTarefaUseCase useCase)
    {
        var response = await useCase.ListarTarefa();

        if (response.Count != 0)
            return Ok(response);

        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> AtualizarTarefa([FromServices] IAtualizarTarefaUseCase useCase, [FromBody] AtualizarTarefaRequest request)
    {
        await useCase.AtualizarTarefa(request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{tarefaId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseError), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeletarTarefa([FromServices] IDeletarTarefaUseCase useCase, [FromRoute] Guid tarefaId)
    {
        var tarefa = await useCase.DeletarTarefa(tarefaId);

        return NoContent();
    }
}
