using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Application.Security;
public interface ILoggedUser
{
    Task<Usuario> Get();
}
