namespace Desafio.Application.Security;
public interface ITokenProvider
{
    string TokenOnRequest();
}