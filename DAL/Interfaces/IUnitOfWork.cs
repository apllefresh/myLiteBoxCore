using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<InventoryDate> InventoryDates { get; }
        IRepository<InventoryHead> InventoryHeads { get; }
        IRepository<InventoryBody> InventoryBodies { get; }
        IRepository<InventoryResult> InventoryResults { get; }
        
        IRepository<Good> Goods { get; }
        void Save();
    }
}
