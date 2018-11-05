using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBLLService<TBL, TDA> where TBL : class where TDA : class
    {
        IReadOnlyCollection<TBL> GetAllItems();
        Task<TBL> GetItemById(int id);
        Task Update(TBL item);
        Task Delete(int id);
        Task Create(TBL item);
    }
}
