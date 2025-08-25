using AutoMapper;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Repositories.Especificas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.UseCase.Usuario.Listar;
public class ListaUsuariosUseCase : IListaUsuariosUseCase
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IMapper _mapper;

    public ListaUsuariosUseCase(IUsuarioRepository usuarioRepository, IMapper mapper)
    {
        _usuarioRepository = usuarioRepository;
        _mapper = mapper;
    }

    public async Task<List<ListaUsuarioResponse>> ListarUsuarios()
    {
        var listaUsuarios = await _usuarioRepository.ObterTodosAsync();

        return _mapper.Map<List<ListaUsuarioResponse>>(listaUsuarios);
    }
}
