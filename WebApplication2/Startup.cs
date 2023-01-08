using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using WebApplication2.DomainClients.Domain.Repositories;
using WebApplication2.DomainClients.Domain.Services;
using WebApplication2.DomainClients.Persistence.Repositories;
using WebApplication2.DomainClients.Services;
using WebApplication2.Shared.Domain.Repositories;
using WebApplication2.Shared.Persistence.Context;
using WebApplication2.Shared.Persistence.Repositories;

namespace WebApplication2
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
            
            services.AddDbContext<AppDbContext>(options =>
            {
                string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
                string dbName = Environment.GetEnvironmentVariable("DB_NAME");
                string dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
                options.UseSqlServer($"server={dbHost}; user=sa; database={dbName}; password={dbPassword};");
                Console.Write(dbHost + dbName + dbPassword);
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "ClientsAPI", Version = "v1"});
            });
            
            // Lowercase Endpoints
            services.AddRouting(options => options.LowercaseUrls = true);

            // DbContext
            services.AddDbContext<AppDbContext>();
            
            //Dependency Injection Configuration
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
            
            // AutoMapper Configuration
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*if (env.IsDevelopment())
            {*/
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientsAPI v1"));
            /*}*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}