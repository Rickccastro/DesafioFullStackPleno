using AutoMapper;
using Desafio.Communication.Requests.Usuario;
using Desafio.Domain.Entities;

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
        CreateMap<UsuarioRequest, Usuario>()
        .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
    private void EntidadeParaResponse()
    {
   
    }
}