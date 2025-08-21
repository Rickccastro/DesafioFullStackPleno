using Desafio.Application.UseCase.Tarefa.Atualizar;
using Desafio.Application.UseCase.Tarefa.Criar;
using Desafio.Application.UseCase.Tarefa.Deletar;
using Desafio.Communication.Requests.Tarefa;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers;
[Route("[controller]")]
[ApiController]
public class TarefasController : ControllerBase
{
    [Route("criar-tarefa")]
    [HttpPost]
    public async Task<ActionResult> CriarTarefa([FromServices] ICriarTarefaUseCase useCase, [FromBody] CriarTarefaRequest request)
    {
        var nomeUsuario = await useCase.CriarTarefa(request);

        return Ok(nomeUsuario);
    }
    [Route("atualizar-tarefa")]
    [HttpPut]
    public async Task<ActionResult> AtualizarTarefa([FromServices] IAtualizarTarefaUseCase useCase, [FromBody] AtualizarTarefaRequest request)
    {
        var nomeUsuario = await useCase.AtualizarTarefa(request);

        return Ok(nomeUsuario);
    }
    [Route("deletar-tarefa")]
    [HttpPut]
    public async Task<ActionResult> AtualizarTarefa([FromServices] IDeletarTarefaUseCase useCase, [FromBody] DeletarTarefaRequest request)
    {
        var nomeUsuario = await useCase.DeletarTarefa(request);

        return Ok(nomeUsuario);
    }
}
