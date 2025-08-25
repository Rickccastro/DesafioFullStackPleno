using Desafio.Application.Security;
using Desafio.Domain.Entities;
using Moq;

namespace CommonTestsUtilities.LoggedUser;
public class LoggedUserBuilder
{
    public static ILoggedUser Build(Usuario user)
    {
        var mock = new Mock<ILoggedUser>();

        mock.Setup(loggedUser => loggedUser.Get()).ReturnsAsync(user);

        return mock.Object;
    }
}