using AutoMapper;
using Desafio.Communication.Requests.Login;
using Desafio.Communication.Requests.Tarefa;
using Desafio.Communication.Requests.Usuario;
using Desafio.Communication.Responses.Login;
using Desafio.Communication.Responses.Tarefa;
using Desafio.Communication.Responses.Usuario;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;
using AutoMapper.Extensions.EnumMapping;


namespace Desafio.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestParaEntidade();
        EntidadeParaResponse();
        MappingEnumToString();
    }
    private void RequestParaEntidade()
    {
        CreateMap<CriarUsuarioRequest, Usuario>()
        .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<CriarTarefaRequest, Tarefa>()
        .ForMember(dest => dest.Id, opt => opt.Ignore());

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


    private void MappingEnumToString()
    {
        CreateMap<string, StatusTarefa>()
         .ConvertUsing(src => Enum.Parse<StatusTarefa>(src,true));

        CreateMap<StatusTarefa, string>()
            .ConvertUsing(status => status.ToString());

        CreateMap<Perfis, string>()
            .ConvertUsing(status => status.ToString());
    }
}