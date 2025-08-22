using Bogus;
using Desafio.Domain.Entities;
using Desafio.Domain.Enums;

namespace CommonTestsUtilities.Entities;
public class UsuarioBuilder
{
    public static Usuario Build(Perfis perfil = Perfis.Usuario)
    {
        return new Faker<Usuario>()
            .RuleFor(u => u.Id, _ => Guid.NewGuid())
            .RuleFor(u => u.Nome, faker => faker.Person.FirstName)
            .RuleFor(u => u.Email, (faker, user) => faker.Internet.Email(user.Nome))
            .RuleFor(u => u.Senha, faker => faker.Internet.Password())
            .RuleFor(u => u.Perfil, _ => perfil)
            .Generate();
    }

}
