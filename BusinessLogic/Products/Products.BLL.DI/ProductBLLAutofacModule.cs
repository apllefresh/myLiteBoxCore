using System;
using System.Collections.Generic;
using Autofac;
using AutoMapper;
using Products.BLL.Contract.Interfaces;
using Products.BLL.Services;

namespace Products.BLL.DI
{
    public class ProductBLLAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentService>()
                .As<IDepartmentService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductGroupService>()
                .As<IProductGroupService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>()
                .As<IProductService>()
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
