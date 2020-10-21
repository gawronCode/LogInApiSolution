using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogInApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace LogInApi
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            var builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = Configuration.GetConnectionString("LogInApiConnection");
            builder.UserID = Configuration["UserID"];
            builder.Password = Configuration["Password"];

            services.AddDbContext<AppClientContext>(opt => opt.UseSqlServer(GetConnectionString()));

            services.AddControllers();
            services.AddScoped<ILogInRepository, SqlLogInRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.ConnectionString = Configuration.GetConnectionString("LogInApiConnection");
            builder.UserID = Configuration["UserID"];
            builder.Password = Configuration["Password"];
            return builder.ConnectionString;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
    }
}
