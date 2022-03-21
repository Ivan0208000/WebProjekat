using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel.Models;
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

namespace hotel
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
           services.AddDbContext<HotelPrContext>(options =>
               options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("HotelCS")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hotel", Version = "v1" });
            });
             services.AddCors(p => 
            {
                p.AddPolicy("CORS", builder => 
                {
                    builder.WithOrigins(new string[]
                    {
                       "http://localhost:8080",
                       "https://localhost:8080",
                       "http://127.0.0.1:8080",
                       "https://127.0.0.1:8080",
                       "http://localhost:5001",
                       "https://localhost:5001",
                       "http://127.0.0.1:5001",
                       "https://127.0.0.1:5001",
                       "http://localhost:5500",
                       "https://localhost:5500",
                       "http://127.0.0.1:5500",
                       "https://127.0.0.1:5500"
                    })
                    .AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hotel v1"));
            }
            app.UseCors("CORS");
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
