using Bogus;
using Desafio.Communication.Requests.Usuario;

namespace CommonTestsUtilities.Requests.Usuario;
public class CriarUsuarioRequestBuild
{
    public static CriarUsuarioRequest Build()
    {
        return new Faker<CriarUsuarioRequest>()
            .RuleFor(u => u.Nome, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Nome))
            .RuleFor(u => u.Senha, faker => faker.Internet.Password())
            .RuleFor(u => u.Perfil, _ => "Usuario")
            .Generate();
    }
}
