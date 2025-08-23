namespace Desafio.Exceptions.ExceptionBase;

public abstract class DesafioException : SystemException
{
    protected DesafioException(string message) : base(message)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}