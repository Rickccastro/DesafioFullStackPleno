using AutoMapper;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Domain.Repositories;
using Desafio.Domain.Repositories.Especificas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var ultimasCincoTarefas = await _tarefaRepository.ObterUltimasCincoAsync();

        return _mapper.Map<List<TarefaResponse>>(ultimasCincoTarefas);
    }
}
