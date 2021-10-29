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
using SuperHeroCore.Issuer;
using SuperHeroCore.Issuer.Behavior;
using SuperHeroCore.Logs;
using SuperHeroCore.Logs.Behavior;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.Mapper.Configuration;
using SuperHeroMediator;
using SuperHeroRepository;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using SuperHeroRepository.Infrastructure;
using SuperHeroRepository.Lookup;
using SuperHeroService.Handlers;
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
            Console.WriteLine("ConfigureServices");

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetCompleteHeroByPublicIdRequestHandler));
            services.AddMediatR(typeof(ListAllHeroesRequestHandler));
            services.AddMediatR(typeof(ListAllHeroesPaginatedRequestHandler));
            services.AddControllers();

            services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            services.AddTransient<IDbSession, DbSession>();

            services.AddTransient<IHeroLookup, HeroLookup>();
            services.AddTransient<IExternalApiLookup, ExternalApiLookup>();

            services.AddTransient<IRest, Rest>();
            services.AddTransient<IApiConfiguration, ApiConfiguration>();

            services.AddSingleton<IIssuer, Issuer>();
            services.AddTransient<ILogManager, LogManager>();
            services.AddSingleton<ILogService, LogService>();


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
            Console.WriteLine("Configure");

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

            serviceProvider.GetService<IDatabaseConfiguration>().DatabaseName = Configuration["DatabaseName"];
            serviceProvider.GetService<IDatabaseConfiguration>().DatabaseServer = Configuration["DatabaseServer"];
            serviceProvider.GetService<IDatabaseConfiguration>().DatabaseUserId = Configuration["DatabaseUserId"];
            serviceProvider.GetService<IDatabaseConfiguration>().DatabasePassword = Configuration["DatabasePassword"];
            serviceProvider.GetService<IDatabaseConfiguration>().DatabaseHost = Configuration["DatabaseHost"];
            serviceProvider.GetService<IDatabaseConfiguration>().DatabasePort = Configuration["DatabasePort"];

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Super Hero API");
            });
        }
    }
}