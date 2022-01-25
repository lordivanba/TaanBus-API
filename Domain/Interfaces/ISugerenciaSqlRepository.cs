

using System.Collections.Generic;
using System.Threading.Tasks;
using taanbus.domain.entities;

namespace taanbus.Domain.Interfaces{
    public interface ISugerenciaSqlRepository{
        Task<IEnumerable<Sugerencia>> GetSugerencias();
        
    }
}