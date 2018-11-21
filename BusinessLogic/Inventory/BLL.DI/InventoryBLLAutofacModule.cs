using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Inventory.BLL.Contract.Interfaces;
using Inventory.BLL.Services;
using Inventory.DAL.Contract.Interfaces;

namespace Inventory.BLL.DI
{
    public class InventoryBLLAutofacModule : Module
    {
        private readonly string _productServiceUrl;

        public InventoryBLLAutofacModule(string productServiceUrl)
        {
            _productServiceUrl = productServiceUrl
                ?? throw new ArgumentNullException(nameof(productServiceUrl));
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InventoryHeadService>()
                .As<IInventoryHeadService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InventoryBodyService>()
                .As<IInventoryBodyService>()
                .InstancePerLifetimeScope();


            builder.Register(context => new InventoryBodyService
            (
                repository: context.Resolve<IInventoryBodyRepository>(),
                mapper: context.Resolve<MapperConfiguration>().CreateMapper(context.Resolve),
                productApiBaseUrl: _productServiceUrl)
            ).As<IInventoryBodyService>();

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
