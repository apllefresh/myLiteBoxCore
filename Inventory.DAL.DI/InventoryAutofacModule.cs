using Autofac;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.Repositories;
using Inventory.DAL.EF;

namespace Inventory.DAL.DI
{
    public class InventoryAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryBodyRepository>()
                .As<IInventoryBodyRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateRepository>()
                .As<IInventoryDateRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryHeadRepository>()
                .As<IInventoryHeadRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryResultRepository>()
                .As<IInventoryResultRepository>()
                .InstancePerLifetimeScope();
           
            builder.RegisterType<DataAccessContext>()
                .As<DataAccessContext>()
                .InstancePerLifetimeScope();
        }
    }
}
