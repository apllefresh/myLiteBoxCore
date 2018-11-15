using System.Collections.Generic;
using System.Threading.Tasks;
using B = BLL.Entities;
using D = DAL.Entities;

namespace BLL.Interfaces
{
    public interface IInventoryHeadService : IBLLService<B.InventoryHead, D.InventoryHead>
    {
        Task<IReadOnlyCollection<B.InventoryHead>> GetAllItems(int id);
    }
}
