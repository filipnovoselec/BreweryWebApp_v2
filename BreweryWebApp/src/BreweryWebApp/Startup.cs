using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.ResolveAnything;
using AutoMapper;
using BreweryData;
using BreweryData.Repositories;
using BreweryData.Repositories.IRepositories;
using BreweryData.Services;
using BreweryData.Services.IServices;
using BreweryWebApp.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stormpath.AspNetCore;
using Stormpath.Configuration;
using Stormpath.Configuration.Abstractions;

namespace BreweryWebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();

            //AutoMapper.Mapper.Initialize(s => s.AddProfile<MapperConfig>());
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddStormpath(new StormpathConfiguration()
            {
                Application = new ApplicationConfiguration()
                {
                    Href = "https://api.stormpath.com/v1/applications/5mMZufccyTEL1tU4V8ZMnu"
                },
                Client = new ClientConfiguration()
                {
                    ApiKey = new ClientApiKeyConfiguration()
                    {
                        File = "C:\\Users\\filip\\Documents\\BreweryWebApp_v2\\BreweryWebApp_v2\\BreweryWebApp\\src\\BreweryWebApp\\apiKey.properties"
                    }
                }
            });

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddScoped<BreweryContext>(s => new BreweryContext(Configuration["Data:ConnectionString"]));

            var config = new MapperConfiguration(cfg =>
                        {
                            cfg.AddProfile<MapperConfig>();
                            cfg.AddProfile<ModelMapperConfig>();
                        });

            services.AddSingleton<IMapper>(s => new Mapper(config));

            var builder = new ContainerBuilder();
            builder.RegisterType<RecipeRepository>().As<IRecipeRepository>();
            builder.RegisterType<RecipeService>().As<IRecipeService>();
            builder.RegisterType<BeerRepository>().As<IBeerRepository>();
            //builder.RegisterType<BeerService>().As<IBeerService>();

            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            //app.UseStormpath();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
