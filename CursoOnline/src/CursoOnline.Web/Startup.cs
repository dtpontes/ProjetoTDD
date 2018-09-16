﻿using CursoOnline.Domain._Base;
using CursoOnline.Ioc;
using CursoOnline.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CursoOnline.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            StartupIoc.ConfigureServices(services, Configuration);

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke();

                var unityOfWork = (IUnityOfWork)context.RequestServices.GetService(typeof(IUnityOfWork));
                await unityOfWork.Commit();
            });

            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
