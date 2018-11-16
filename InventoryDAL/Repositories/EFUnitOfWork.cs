using InventoryDAL.Interfaces;
using InventoryDAL.EF;
using InventoryDAL.Entities;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InventoryDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private GoodRepository goodRepository;
        private GoodGroupRepository goodGroupRepository;
        private DepartmentRepository departmentRepository;

        private InventoryDateRepository inventoryDateRepository;
        private InventoryResultRepository inventoryResultRepository;
        private InventoryHeadRepository inventoryHeadRepository;
        private InventoryBodyRepository inventoryBodyRepository;

        public EFUnitOfWork()
        {
            //db = new ApplicationContext(configuration);
        }

        public IRepository<Good> Goods
        {
            get
            {
                if (goodRepository == null)
                    goodRepository = new GoodRepository(db);
                return goodRepository;
            }
        }
        public IRepository<GoodGroup> GoodGroups
        {
            get
            {
                if (goodGroupRepository == null)
                    goodGroupRepository = new GoodGroupRepository(db);
                return goodGroupRepository;
            }
        }
        public IRepository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(db);
                return departmentRepository;
            }
        }

        public IRepository<InventoryDate> InventoryDates
        {
            get
            {
                if (inventoryDateRepository == null)
                    inventoryDateRepository = new InventoryDateRepository(db);
                return inventoryDateRepository;
            }
        }
        public IRepository<InventoryResult> InventoryResults
        {
            get
            {
                if (inventoryResultRepository == null)
                    inventoryResultRepository = new InventoryResultRepository(db);
                return inventoryResultRepository;
            }
        }
        public IRepository<InventoryHead> InventoryHeads
        {
            get
            {
                if (inventoryHeadRepository == null)
                    inventoryHeadRepository = new InventoryHeadRepository(db);
                return inventoryHeadRepository;
            }
        }
        public IRepository<InventoryBody> InventoryBodies
        {
            get
            {
                if (inventoryBodyRepository == null)
                    inventoryBodyRepository = new InventoryBodyRepository(db);
                return inventoryBodyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
