using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hwecosystemAPI.Models;
using hwecosystemAPI.Repositories;
using hwecosystemAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace hwecosystemAPI
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
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContextPool<hwecosystemDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IAccountService, AccountRepository>();
            services.AddScoped<IAdministratorService, AdministratorRepository>();
            services.AddScoped<IAuthService, AuthRepository>();
            services.AddScoped<IContributorService, ContributorRepository>();
            services.AddScoped<ICycleService, CycleRepository>();
            services.AddScoped<ILevelService, LevelRepository>();
            services.AddScoped<IRefugeCenterService, RefugeCenterRepository>();
            services.AddScoped<IPishonService, PishonRepository>();
            services.AddScoped<IPishonRefugeeCenterService, PishonRefugeeCenterRepository>();


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            //services.AddSession();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.AddControllers();

            services.AddDistributedMemoryCache();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hwecosystemAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();


            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "hwecosystemAPI V1");
            });
        }
    }
}
