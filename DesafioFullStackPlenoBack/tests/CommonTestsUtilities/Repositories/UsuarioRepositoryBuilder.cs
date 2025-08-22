using Desafio.Domain.Repositories.Especificas;
using Moq;

namespace CommonTestsUtilities.Repositories;
public class UsuarioRepositoryBuilder
{
    public static IUsuarioRepository Build()
    {
        var mock = new Mock<IUsuarioRepository>();

        return mock.Object;
    }
}
