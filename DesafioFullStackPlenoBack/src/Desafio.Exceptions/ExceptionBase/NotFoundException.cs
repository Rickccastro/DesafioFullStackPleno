using Desafio.Exceptions.ExceptionBase;
using System.Net;

namespace Desafio.Exception.ExceptionBase;
public class NotFoundException : DesafioException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}