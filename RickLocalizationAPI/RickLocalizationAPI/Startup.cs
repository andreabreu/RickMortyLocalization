using AutoMapper;
using Domain.Entities;
using Service.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Repositories;
using RickLocalizationAPI.Models;
using Service;
using Service.Services;

namespace RickLocalizationAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string _allowLocalOrigin = "AllowLocal";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(_allowLocalOrigin,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<MyContext>(
                 options => options.UseSqlServer(Configuration.GetConnectionString("MyContext")));

            services.AddSwaggerGen();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Rick, RickModel>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));


                config.CreateMap<Morty, MortyModel>();
                config.CreateMap<Dimension, DimensionModel>();
                config.CreateMap<RickDimensionInputModel, RickDimension>();
                config.CreateMap<RickDimension, RickDimensionModel>();


            }).CreateMapper());


            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


            services.AddScoped<IDimensionService, DimensionService>();
            services.AddScoped<IDimensionRepository, DimensionRepository>();

            services.AddScoped<IMortyService, MortyService>();
            services.AddScoped<IMortyRepository, MortyRepository>();

            services.AddScoped<IRickService, RickService>();
            services.AddScoped<IRickRepository, RickRepository>();

            services.AddHttpContextAccessor();
            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MyContext>();
                context.Database.Migrate();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_allowLocalOrigin);

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
