using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperHeroMediator;
using SuperHeroRepository;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using SuperHeroRepository.Lookup;
using SuperHeroRepository.Persister;
using SuperHeroService.CompleteHero;
using System;
using System.Reflection;

namespace SuperHeroApi
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
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetCompleteHeroByIdRequestHandler));
            services.AddControllers();

            services.AddSingleton(new DatabaseConfiguration { Name = Configuration["DatabaseName"] });

            services.AddSingleton<IDatabaseStartUp, DatabaseStartUp>();
            services.AddSingleton<IHeroLookup, HeroLookup>();
            services.AddSingleton<IHeroPersister, HeroPersister>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ServiceLocator.SetLocatorProvider(app.ApplicationServices);

            serviceProvider.GetService<IDatabaseStartUp>().Setup();
        }
    }
}
