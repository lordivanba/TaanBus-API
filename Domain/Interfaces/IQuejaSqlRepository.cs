
using System.Collections.Generic;
using System.Threading.Tasks;
using taanbus.Domain.Entities;

namespace taanbus.Domain.Interfaces{
    public interface IQuejaSqlRepository{
        Task<IEnumerable<Queja>> GetQuejas();
        Task<Queja> GetQuejaById(int id);
        Task<IEnumerable<Queja>> GetUserQuejas(int id);
        Task<IEnumerable<Queja>> GetQuejasAprobadas();
        Task<bool> UpdateStatus(int id,int status);
        Task<int> CreateQueja(Queja queja);
        Task<bool> UpdateQueja(int id, Queja queja);
        Task<bool> DeleteQueja(int id);
    }
}