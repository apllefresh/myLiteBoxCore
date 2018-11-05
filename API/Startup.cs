﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BLL.DI;
using DAL.DI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace API
{
       public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            public IServiceProvider ConfigureServices(IServiceCollection services)
            {
                services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                var builder = new ContainerBuilder();
                builder.RegisterModule(new DALAutofacModule());
                builder.RegisterModule(new BLLAutofacModule());
                builder.Populate(services);
                var container = builder.Build();
                return new AutofacServiceProvider(container);
            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseMvc();
            }
        }
    
}
