using Autofac;
using Products.DAL.Contract.Interfaces;
using Products.DAL.Repositories;
using Products.DAL.EF;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace Products.DAL.DI
{
    public class ProductDALAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentRepository>()
                .As<IDepartmentRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductGroupRepository>()
                .As<IProductGroupRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
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
