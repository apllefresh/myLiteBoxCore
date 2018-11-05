using System;
using System.Collections.Generic;

using BLL.Interfaces;
using BLL.Services;
using Autofac;
using AutoMapper;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.DI
{
    public class BLLAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryService>()
                .As<IInventoryService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InventoryDateRepository>()
                 .As<InventoryDateRepository>()
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
