using AutoMapper;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Domain.Repositories.Especificas;

namespace Desafio.Application.UseCase.Tarefa.Listar;
public class ListarTarefaUseCase : IListarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;

    public ListarTarefaUseCase(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public async Task<List<TarefaResponse>> ListarTarefa()
    {
        var ultimasCincoTarefas = await _tarefaRepository.ObterTodosAsync();

        return _mapper.Map<List<TarefaResponse>>(ultimasCincoTarefas);
    }
}
