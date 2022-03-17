using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taanbus.Domain.Entities;
using taanbus.Domain.Interfaces;
using taanbus.Infrastructure.Data;

namespace taanbus.Infrastructure.Repositories
{
    public class UsuarioSqlRepository  : IUsuarioSqlRepository
    {
        private readonly taanbusdbContext _context;

        public UsuarioSqlRepository(taanbusdbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUser(string username)
        {
            try{
                var user =_context.Usuario.FirstOrDefaultAsync(u => u.Username == username);
                return await user;
            } catch (Exception){
                return null;
            }
        }

        public async Task<IEnumerable<Usuario>> GetUsers(){
            var query = _context.Usuario.Select(x => x);
            return await query.ToListAsync();
        }

        public async Task<int> CreateUser(Usuario user)
        {
                   if (user == null)
                throw new ArgumentNullException("No se pudo registrar el usuario a falta de informacion");
            try
            {
                var entity = user;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if (rows <= 0)
                    throw new Exception("Ocurrio un fallo al intentar registrar el usuario, verifica tu informacion");

                return entity.Id;
            }
            catch (DbUpdateException exEf)
            {
                throw new Exception("No se pudo registrar la sugerencia a falta de informacion");
            }
        }
        
    }
}