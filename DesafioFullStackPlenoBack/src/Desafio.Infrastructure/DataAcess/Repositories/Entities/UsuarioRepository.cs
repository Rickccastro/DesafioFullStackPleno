using Desafio.Domain.Entities;
using Desafio.Domain.Repositories.Especificas;
using Desafio.Infraestructure.DataAccess;

namespace Desafio.Infrastructure.DataAcess.Repositories.Entities;
public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DesafioDbContext context) : base(context)
    {
    }
}