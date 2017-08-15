using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WorkOutous.Data;
using Microsoft.EntityFrameworkCore;
using WorkOutous.Services;
using GameSquad.Repositories;

namespace WorkOutous
{
    public class Startup
    {
        private object RouteParameter;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //add service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISearchExercisesService, SearchExercisesService>();
            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<IWorkOutService, WorkOutService>();

            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataBaseContexts>(options =>
                {
                    options.UseSqlServer(connection);
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "SearchExercises",
                    template: "api/{controller}/{action}/{id}",
                    defaults: new { controller = "SearchExercises", action = "GetExercises", input = RouteParameter }
                );
                routes.MapRoute(
                    name: "ActionApi",
                    template: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
