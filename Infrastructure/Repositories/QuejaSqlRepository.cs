using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taanbus.domain.entities;
using taanbus.Domain.Interfaces;
using taanbus.Infrastructure.Data;

namespace taanbus.Infrastructure.Repositories{
    public class QuejaSqlRepository : IQuejaSqlRepository
    {
        private readonly taanbusdbContext _context;

        public QuejaSqlRepository()
        {
            _context = new taanbusdbContext();
        }
        public async Task<IEnumerable<Queja>> GetQuejas(){
            var query = _context.Queja.Select(x => x);
            return await query.ToListAsync();
        }

        public async Task<Queja> GetQuejaById(int id){
            var query = _context.Queja.FindAsync(id);
            return await query;
        }

        public async Task<int> CreateQueja(Queja queja){
            if(queja == null)
                throw new ArgumentNullException("No se pudo registrar la queja a falta de informacion");
            try{
                queja.FechaRegistro = DateTime.Now;
                var entity = queja;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if(rows <= 0)
                    throw new Exception("Ocurrio un fallo al intentar registrar la queja, verifica tu informacion");

                return entity.Id;
            }
            catch(DbUpdateException exEf){
                throw new Exception("No se pudo registrar la sugerencia a falta de informacion");
            }
        }
    }
}