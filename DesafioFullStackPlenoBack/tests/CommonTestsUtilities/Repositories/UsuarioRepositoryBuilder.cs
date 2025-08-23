using Desafio.Domain.Entities;
using Desafio.Domain.Repositories.Especificas;
using Moq;
using System.Linq.Expressions;

namespace CommonTestsUtilities.Repositories;
public class UsuarioRepositoryBuilder
{
    private readonly Mock<IUsuarioRepository> _repository;

    public UsuarioRepositoryBuilder()
    {
        _repository = new Mock<IUsuarioRepository>();
    }

    public UsuarioRepositoryBuilder ObterPorId(Usuario usuario)
    {
        _repository.Setup(r => r.ObterPorIdAsync(usuario.Id))
                   .ReturnsAsync(usuario);

        return this;
    }

    public UsuarioRepositoryBuilder ObterByPropriedade(string email, Usuario usuario)
    {
        _repository
   .Setup(r => r.ObterPorPropriedadeAsync(
      It.IsAny<Expression<Func<Usuario, bool>>>(),
      It.IsAny<Expression<Func<Usuario, object>>[]>()
   ))
   .ReturnsAsync(usuario);


        return this;
    }

    public UsuarioRepositoryBuilder ObterUsuarioPorEmailESenha(string email, string senha, Usuario usuario)
    {
        _repository
            .Setup(r => r.ObterPorPropriedadeAsync(
                It.Is<Expression<Func<Usuario, bool>>>(expr =>
                    expr.Compile()(usuario)
                ),
                It.IsAny<Expression<Func<Usuario, object>>[]>()
            ))
            .ReturnsAsync(usuario);

        return this;
    }


    public IUsuarioRepository Build()
    {
        var mock = new Mock<IUsuarioRepository>();

        return _repository.Object;
    }
}
