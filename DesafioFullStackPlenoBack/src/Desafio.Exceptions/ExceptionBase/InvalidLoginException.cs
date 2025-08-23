using Desafio.Exceptions;
using System.Net;

namespace Desafio.Exceptions.ExceptionBase;
public class InvalidLoginException : DesafioException
{
    public InvalidLoginException() : base(ResourceErrorMessages.EMAIL_OU_SENHA_INVALIDO)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}