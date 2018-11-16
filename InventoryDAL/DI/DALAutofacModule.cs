using Autofac;
using System;
using System.Collections.Generic;
using InventoryDAL.EF;

namespace InventoryDAL.DI
{
    public class DALAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>()
                .As<ApplicationContext>()
                .InstancePerLifetimeScope();
        }
    }
}
