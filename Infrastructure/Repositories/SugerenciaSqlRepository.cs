using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using taanbus.domain.entities;
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
            var query = _context.Sugerencia.Select(x => x);
            return await query.ToListAsync();
        }
    }
}