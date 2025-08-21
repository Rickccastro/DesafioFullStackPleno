using Desafio.Domain.Entities;

namespace Desafio.Application.Security;
public interface IAccessTokenGenerator
{
    string Generate(Usuario usuario);
}