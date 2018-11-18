using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.BLL.Contract.Interfaces
{
    public interface IBusinessLogicService<TBL, TDA> where TBL : class where TDA : class
    {
        Task<IReadOnlyCollection<TBL>> GetAllItems();
        Task<TBL> GetItemById(int id);
        Task Update(TBL item);
        Task Delete(int id);
        Task Create(TBL item);
    }
}
