using AutoMapper;
using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;

namespace Desafio.Application.UseCase.Tarefa.Criar;
public class CriarTarefaUseCase : ICriarTarefaUseCase
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CriarTarefaUseCase(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<TarefaResponse> CriarTarefa(CriarTarefaRequest request)
    {
        var tarefa = _mapper.Map<Domain.Entities.Tarefa>(request);
        tarefa.Id = Guid.NewGuid();

        await _tarefaRepository.AdicionarAsync(tarefa);
        await _unitOfWork.Commit();

        return _mapper.Map<TarefaResponse>(tarefa);
    }
}
