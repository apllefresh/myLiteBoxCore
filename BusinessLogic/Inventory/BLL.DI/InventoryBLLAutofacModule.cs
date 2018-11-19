using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Inventory.BLL.Contract.Interfaces;
using Inventory.BLL.Services;

namespace Inventory.BLL.DI
{
    public class InventoryBLLAutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryHeadService>()
                .As<IInventoryHeadService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryBodyService>()
                .As<IInventoryBodyService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateService>()
                .As<IInventoryDateService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryResultService>()
                .As<IInventoryResultService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventorySpaceService>()
                .As<IInventorySpaceService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateToSpaceMapService>()
                .As<IInventoryDateToSpaceMapService>()
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
