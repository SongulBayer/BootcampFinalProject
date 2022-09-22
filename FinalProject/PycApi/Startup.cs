using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PycApi.Base;
using PycApi.Middleware;
using PycApi.Service;
using PycApi.StartUpExtension;
using PycApi.Data;
using PycApi.Dto;

namespace PycApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static JwtConfig JwtConfig { get; private set; }

     

        public void ConfigureServices(IServiceCollection services)
        {
            //cashe in memory
            services.AddMemoryCache();


            //response cashe  on services
            services.AddControllersWithViews(options =>
                         options.CacheProfiles.Add("Profile45", new CacheProfile
                         {
                             Duration = 45
                         }));


            // hibernate
            var connStr = Configuration.GetConnectionString("PostgreSqlConnection");
            services.AddNHibernatePosgreSql(connStr);

            // Configure JWT Bearer
            JwtConfig = Configuration.GetSection("JwtConfig").Get<JwtConfig>();
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));


            // service
            services.AddServices();
            services.AddJwtBearerAuthentication();
            services.AddCustomizeSwagger();
            services.AddRedisDependencyInjection(Configuration);

            services.AddScoped<IMailService, MailService>();

            services.AddMvc(options => {
                options.Filters.Add(typeof(ResponseGiudAttribute));
            });

            services.AddControllers();
          
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PycApi Tech Company"));
            }


            // middleware
            app.UseMiddleware<HeartbeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();


            // add auth 
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
