using Autofac;
using Inventory.DAL.Contract.Interfaces;
using Inventory.DAL.Repositories;
using Inventory.DAL.EF;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace Inventory.DAL.DI
{
    public class InventoryDALAutofacModule : Module
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
            builder.RegisterType<InventorySpaceRepository>()
                 .As<IInventorySpaceRepository>()
                 .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateToSpaceMapRepository>()
                .As<IInventoryDateToSpaceMapRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataAccessContext>()
                .As<DataAccessContext>()
                .InstancePerLifetimeScope();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
            builder.Register(c => c.Resolve<MapperConfiguration>()
                    .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}
