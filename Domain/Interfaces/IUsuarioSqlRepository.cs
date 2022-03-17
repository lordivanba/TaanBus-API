using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taanbus.Domain.Entities;

namespace taanbus.Domain.Interfaces
{
    public interface IUsuarioSqlRepository
    {
        Task<Usuario> GetUser(string username);
        Task<IEnumerable<Usuario>> GetUsers();
        Task<int> CreateUser(Usuario user);
    }
}