using Bogus;
using Desafio.Communication.Requests.Usuario;

namespace CommonTestsUtilities.Requests.Usuario;
public class AtualizarUsuarioRequestBuild
{
    public static AtualizarUsuarioRequest Build()
    {
        return new Faker<AtualizarUsuarioRequest>()
            .RuleFor(u => u.Id, _ => Guid.NewGuid())
            .RuleFor(u => u.Nome, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Nome))
            .RuleFor(u => u.Senha, faker => faker.Internet.Password())
            .RuleFor(u => u.Perfil, _ => "Usuario")
            .Generate();
    }
}
