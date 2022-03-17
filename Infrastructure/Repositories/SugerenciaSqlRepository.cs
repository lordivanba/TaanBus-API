using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taanbus.Domain.Entities;
using taanbus.Domain.Interfaces;
using taanbus.Infrastructure.Data;

namespace taanbus.Infrastructure.Repositories{
    public class SugerenciaSqlRepository : ISugerenciaSqlRepository
    {
        private readonly taanbusdbContext _context;

        public SugerenciaSqlRepository()
        {
            _context = new taanbusdbContext();
        }

        public async Task<IEnumerable<Sugerencia>> GetSugerencias(){
            var query = _context.Sugerencia.Select(x => x).Include(x => x.User);
            return await query.ToListAsync();
        }

        public async Task<Sugerencia> GetSugerenciaById(int id){
            // var query = _context.Sugerencia.FindAsync(id);
            var query = _context.Sugerencia.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            return await query;
        }

        public async Task<IEnumerable<Sugerencia>> GetUserSugerencias(int id)
        {
            var query = _context.Sugerencia.Where(x => x.UserId == id);
            return await query.ToListAsync();
        }

           public async Task<bool> UpdateStatus(int id,int status)
        {
            var entity = await GetSugerenciaById(id);

            entity.Status = status;
                        var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<int> CreateSugerencia(Sugerencia sugerencia){
            if(sugerencia == null)
                throw new ArgumentNullException("No se pudo registrar la sugerencia a falta de informacion");
                
            try{
                sugerencia.FechaRegistro = DateTime.Now;
                var entity = sugerencia;
                await _context.AddAsync(entity);
                var rows = await _context.SaveChangesAsync();

                if(rows <= 0)
                    throw new Exception("Ocurrio un fallo al intentar registrar la sugerencia, verifica la informacion ingresada");
                return entity.Id;

            } catch(DbUpdateException exEf){
                throw new Exception("No se pudo registrar la sugerencia a falta de informacion");
            }
        }

        public async Task<bool> UpdateSugerencia(int id, Sugerencia sugerencia){
            if(id<= 0 || sugerencia == null)
                throw new ArgumentNullException("La actualizacion no se pudo realizar a falta de informacion");
            var entity = await GetSugerenciaById(id);

            entity.Descripcion = sugerencia.Descripcion;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }

        public async Task<bool> DeleteSugerencia(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("No se pudo eliminar la sugerencia");
            var sugerencia = await GetSugerenciaById(id);
            try{
                _context.Remove(sugerencia);
                await _context.SaveChangesAsync();               
                
                return true;
            } catch (Exception e){
                throw new Exception("No se pudo eliminar la sugerencia");
            }

        }
    }
}