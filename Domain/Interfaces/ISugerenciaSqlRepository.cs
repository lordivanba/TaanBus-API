

using System.Collections.Generic;
using System.Threading.Tasks;
using taanbus.Domain.Entities;

namespace taanbus.Domain.Interfaces
{
    public interface ISugerenciaSqlRepository
    {
        Task<IEnumerable<Sugerencia>> GetSugerencias();
        Task<Sugerencia> GetSugerenciaById(int id);
        Task<IEnumerable<Sugerencia>> GetUserSugerencias(int id);
        Task<IEnumerable<Sugerencia>> GetSugerenciasAprobadas();
        Task<bool> UpdateStatus(int id,int status);
        Task<int> CreateSugerencia(Sugerencia sugerencia);
        Task<bool> UpdateSugerencia(int id, Sugerencia sugerencia);
        Task<bool> DeleteSugerencia(int id);


    }
}