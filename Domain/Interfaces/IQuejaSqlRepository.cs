
using System.Collections.Generic;
using System.Threading.Tasks;
using taanbus.domain.entities;

namespace taanbus.Domain.Interfaces{
    public interface IQuejaSqlRepository{
        Task<IEnumerable<Queja>> GetQuejas();
        Task<Queja> GetQuejaById(int id);
        Task<int> CreateQueja(Queja queja);
        Task<bool> UpdateQueja(int id, Queja queja);
    }
}