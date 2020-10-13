using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiWithCodeFirstApproch.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Versioning;
using WebApiWithCodeFirstApproch.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApiWithCodeFirstApproch
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
            services.AddDbContext<ProductsDBContext>(option => option.UseSqlServer("Data Source=DESKTOP-19MSM16\\SQLEXPRESS;Initial Catalog=ProductsDB;Integrated Security = True"));

            //Caching
            services.AddResponseCaching();

            //versioning
            services.AddApiVersioning(Options => Options.AssumeDefaultVersionWhenUnspecified = true);
            //Versioning via Media Type --in Headers sending information about version
            services.AddApiVersioning(o => o.ApiVersionReader = new MediaTypeApiVersionReader());

            //Reposit Pattern
            services.AddScoped<IProducts, ProductsRespository>();

            //API documentation
        // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Documentation", Version = "Version 1.0" });
            });

            services.AddMvc();

            // 1. Add Authentication Services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://productsapi.us.auth0.com/";
                options.Audience = "https://localhost:44325/";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ProductsDBContext productsDBContext)
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

            //to use caching
            app.UseResponseCaching();



            //  productsDBContext.Database.EnsureCreated();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api for Products"));

            
        }
    }
}
