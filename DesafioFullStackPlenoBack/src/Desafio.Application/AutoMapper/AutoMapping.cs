using AutoMapper;
using Desafio.Communication.Requests.Login;
using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Login;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;

namespace Desafio.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestParaEntidade();
        EntidadeParaResponse();
    }
    private void RequestParaEntidade()
    {
        CreateMap<CriarUsuarioRequest, Usuario>()
        .ForMember(dest => dest.Id, opt => opt.Ignore())
        .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => Enum.Parse<Perfis>(src.Perfil, true)));

        CreateMap<AtualizarUsuarioRequest, Usuario>();
        CreateMap<AtualizarTarefaRequest, Tarefa>();
    }
    private void EntidadeParaResponse()
    {
        CreateMap<Usuario, UsuarioResponse>();
        CreateMap<Tarefa, TarefaResponse>();
        CreateMap<Usuario, LoginUsuarioResponse>()
.ForMember(dest => dest.Token, opt => opt.Ignore());
    }
}