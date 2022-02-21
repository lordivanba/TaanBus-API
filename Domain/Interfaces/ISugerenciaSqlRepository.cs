

using System.Collections.Generic;
using System.Threading.Tasks;
using taanbus.domain.entities;

namespace taanbus.Domain.Interfaces{
    public interface ISugerenciaSqlRepository{
        Task<IEnumerable<Sugerencia>> GetSugerencias();
        Task<Sugerencia> GetSugerenciaById(int id);
        Task<int> CreateSugerencia(Sugerencia sugerencia);
        Task<bool> UpdateSugerencia(int id, Sugerencia sugerencia);
        Task<bool> DeleteSugerencia(int id);
        
        
    }
}