using System.Net;

namespace Desafio.Exception.ExceptionBase;
public class InvalidLoginException : DesafioException
{
    public InvalidLoginException() : base(ResourceErrorMessages.ERRO_EMAIL_OU_SENHA_INVALIDO)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}