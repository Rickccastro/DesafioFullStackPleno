using Desafio.Application.UseCase.Tarefa.Atualizar;
using Desafio.Application.UseCase.Tarefa.Criar;
using Desafio.Application.UseCase.Tarefa.Deletar;
using Desafio.Application.UseCase.Tarefa.Listar;
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
        var tarefa = await useCase.CriarTarefa(request);

        return Ok(tarefa);
    }
    [Route("listagem-tarefa")]
    [HttpPost]
    public async Task<ActionResult> ListaTarefa([FromServices] IListarTarefaUseCase useCase)
    {
        var tarefa = await useCase.ListarTarefa();

        return Ok(tarefa);
    }
    [Route("atualizar-tarefa")]
    [HttpPut]
    public async Task<ActionResult> AtualizarTarefa([FromServices] IAtualizarTarefaUseCase useCase, [FromBody] AtualizarTarefaRequest request)
    {
        var tarefa = await useCase.AtualizarTarefa(request);

        return Ok(tarefa);
    }
    [Route("deletar-tarefa")]
    [HttpPut]
    public async Task<ActionResult> DeletarTarefa([FromServices] IDeletarTarefaUseCase useCase, [FromBody] DeletarTarefaRequest request)
    {
        var tarefa = await useCase.DeletarTarefa(request);

        return Ok(tarefa);
    }
}
