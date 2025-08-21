using Desafio.Application.Security;
using Desafio.Domain.Entities;
using Desafio.Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Desafio.Infrastructure.Services.Security;
internal class LoggedUser : ILoggedUser
{
    private readonly DesafioDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(DesafioDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;
        _tokenProvider = tokenProvider;
    }

    public async Task<Usuario> Get()
    {
        string token = _tokenProvider.TokenOnRequest();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return await _dbContext
            .Usuarios
            .AsNoTracking()
            .FirstAsync(user => user.Id == Guid.Parse(identifier));
    }
}
