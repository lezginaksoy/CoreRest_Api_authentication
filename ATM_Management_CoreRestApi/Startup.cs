using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ATM_Management_CoreRestApi.Data.Repository;
using ATM_Management_CoreRestApi.Data.Interface;
using Swashbuckle.AspNetCore.Swagger;
using ATM_Management_CoreRestApi.Data.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ATM_Management_CoreRestApi
{
    public class Startup
    {
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

            services.AddEntityFrameworkNpgsql().AddDbContext<AtmManagmentContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("AtmConnection")));

            services.AddTransient<ITerminalRepository, TerminalRepository>();

             // it is a Bearer token
            services.AddAuthentication("Bearer") 
              .AddIdentityServerAuthentication(options =>
              {
                  options.Authority = "http://localhost:52233"; //Identity Server URL
                    options.RequireHttpsMetadata = false; // make it false since we are not using https
                    options.ApiName = "token"; //api name which should be registered in IdentityServer
                });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Core RESTful API", Description = "using swagger for core rest api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {          
            app.UseMvc();

            app.UseSwagger();
            app.UseAuthentication(); // add the Authentication middleware

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " Core RESTful API v1");
            });


        }
    }
}
