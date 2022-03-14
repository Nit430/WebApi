using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApi.Repository;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, TestRepository>();
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.TryAddScoped<IEmployeeRepository, EmployeeRepository>();
            services.TryAddScoped<IEmployeeRepository, TestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*Demonstration of Run(),Use(),next() middleware
            app.Use(async(context,next) =>
            {
                await context.Response.WriteAsync("Hello from 1st Middleware\n");
                await next();
                await context.Response.WriteAsync("Hello from 1st Use\n");
            });

            //app.Map("/hello", customConfiguration);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 2nd Use\n");
                await next();
                await context.Response.WriteAsync("Hello from 2nd Use-2\n");
            });

            //app.Map("/hello", customConfiguration);

            app.UseMiddleware<CustomMiddleware>();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Request completed\n");
            });

            app.Map("/hello", customConfiguration);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from 1st Middleware\n");
                await next();
                await context.Response.WriteAsync("Hello from 1st Use\n");
            });*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void customConfiguration(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from Custom Map code\n");
            });
        }
    }
}
