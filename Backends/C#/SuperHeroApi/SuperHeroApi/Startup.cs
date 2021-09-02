using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SuperHeroCore.Infrastructure;
using SuperHeroCore.Infrastructure.Behavior;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.Mapper.Configuration;
using SuperHeroMediator;
using SuperHeroRepository;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using SuperHeroRepository.Infrastructure;
using SuperHeroRepository.Lookup;
using SuperHeroRepository.Persister;
using SuperHeroService.Handlers;
using SuperHeroService.Infrastructure;
using SuperHeroService.Infrastructure.Behavior;
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
            services.AddMediatR(typeof(GetCompleteHeroByPublicIdRequestHandler));
            services.AddMediatR(typeof(ListAllHeroesRequestHandler));
            services.AddControllers();

            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddTransient<IDbSession, DbSession>();

            services.AddSingleton<IDatabaseStartUp, DatabaseStartUp>();
            services.AddTransient<IHeroLookup, HeroLookup>();
            services.AddTransient<IHeroPersister, HeroPersister>();
            services.AddSingleton<IDatabaseSetupService, DatabaseSetupService>();
            services.AddTransient<IExternalApiLookup, ExternalApiLookup>();

            services.AddTransient<IRest, Rest>();
            services.AddTransient<IApiConfiguration, ApiConfiguration>();

            var mapperConfig = AutoMapperConfiguration.Register();
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Super Hero API",
                        Version = "v1",
                        Description = "An API with information of ALL Suepr Heroes!"
                    });
            });
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

            serviceProvider.GetService<IDatabaseConfiguration>().Name = Configuration["DatabaseName"];
            serviceProvider.GetService<IDatabaseStartUp>().Setup();
            serviceProvider.GetService<IDatabaseSetupService>().FillDatabase();


            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Super Hero API");
            });
        }
    }
}