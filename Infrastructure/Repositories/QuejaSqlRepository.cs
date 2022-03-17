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
    public class QuejaSqlRepository : IQuejaSqlRepository
    {
        private readonly taanbusdbContext _context;

        public QuejaSqlRepository()
        {
            _context = new taanbusdbContext();
        }
        public async Task<IEnumerable<Queja>> GetQuejas()
        {
            var query = _context.Queja.Select(x => x).Include(x => x.User);
            return await query.ToListAsync();
        }

        public async Task<Queja> GetQuejaById(int id)
        {
            // var query = _context.Queja.FindAsync(id);
            var query = _context.Queja.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            return await query;
        }

        public async Task<IEnumerable<Queja>> GetUserQuejas(int id)
        {
            var query = _context.Queja.Where(x => x.UserId == id);
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateStatus(int id,int status)
        {
            var entity = await GetQuejaById(id);

            entity.Status = status;
            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
        public async Task<int> CreateQueja(Queja queja)
        {
            if (queja == null)
                throw new ArgumentNullException("No se pudo registrar la queja a falta de informacion");
            try
            {
                queja.FechaRegistro = DateTime.Now;
                var entity = queja;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if (rows <= 0)
                    throw new Exception("Ocurrio un fallo al intentar registrar la queja, verifica tu informacion");

                return entity.Id;
            }
            catch (DbUpdateException exEf)
            {
                throw new Exception("No se pudo registrar la sugerencia a falta de informacion");
            }
        }

        public async Task<bool> UpdateQueja(int id, Queja queja)
        {
            if (id <= 0 || queja == null)
                throw new ArgumentNullException("La actualizacion no se pudo realizar a falta de informacion");
            var entity = await GetQuejaById(id);

            entity.MotivoQueja = queja.MotivoQueja;
            entity.FechaHechos = queja.FechaHechos;
            entity.Descripcion = queja.Descripcion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteQueja(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("No se pudo eliminar la queja");
            var queja = await GetQuejaById(id);
            try{
                _context.Remove(queja);
                await _context.SaveChangesAsync();               
                
                return true;
            } catch (Exception e){
                throw new Exception("No se pudo eliminar el registro");
            }

        }
    }
}