using Desafio.Domain.Repositories.Especificas;
using Moq;

namespace CommonTestsUtilities.Repositories;
public class TarefaRepositoryBuilder
{
    public static ITarefaRepository Build()
    {
        var mock = new Mock<ITarefaRepository>();

        return mock.Object;
    }
}
