using System;
using System.Collections.Generic;

using BLL.Interfaces;
using BLL.Services;
using Autofac;
using AutoMapper;
using InventoryDAL.Interfaces;
using InventoryDAL.Repositories;

namespace BLL.DI
{
    public class BLLAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryDateService>()
                .As<IInventoryDateService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateRepository>()
                 .As<InventoryDateRepository>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<InventoryHeadService>()
                .As<IInventoryHeadService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryHeadRepository>()
                 .As<InventoryHeadRepository>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<InventoryBodyService>()
                .As<IInventoryBodyService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryBodyRepository>()
                 .As<InventoryBodyRepository>()
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
