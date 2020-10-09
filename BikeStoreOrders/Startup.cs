using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using BikeStoreOrders.Application;
using BikeStoreOrders.Infrastructure;
using BikeStoreOrders.Infrastructure.Automapper;
using BikeStoreOrders.Infrastructure.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BikeStoreOrders
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServices(Configuration, Env);
            //            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BikeStoreOrders App API",
                    Description = "Sample API documentation for BikeStoreOrders App"
                });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.ConfigureProfiles();
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<InfrastructureModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BikeStoreOrders Test API v1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                //                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler(
                                options =>
                                {
                                    options.Run(
                                        async context =>
                                        {
                                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                            context.Response.ContentType = "text/html";
                                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                                            if (null != exceptionObject)
                                            {
                                                var errorMessage = $"<b>Error: {exceptionObject.Error.Message}</b>{exceptionObject.Error.StackTrace}";
                                                await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                                            }
                                        });
                                }
                            );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
