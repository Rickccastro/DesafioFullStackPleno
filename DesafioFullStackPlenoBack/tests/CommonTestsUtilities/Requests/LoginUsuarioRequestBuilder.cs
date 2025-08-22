using Bogus;
using Desafio.Communication.Requests.Login;

namespace CommonTestsUtilities.Requests;
public class LoginUsuarioRequestBuilder
{
    public static LoginUsuarioRequest Build()
    {
        return new Faker<LoginUsuarioRequest>()
                        .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email())
                        .RuleFor(u => u.Senha, faker => faker.Internet.Password());
    }
}
