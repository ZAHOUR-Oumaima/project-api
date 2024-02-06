using HolidayRequestsApp.Infrastructure.Data;
using HolidayRequestsApp.Infrastructure.Repositories.HolidayRequests;
using HolidayRequestsApp.Services.HolidayRequests;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayRequestsApp
{
    public class Startup
    {
        private const string DefaultCorsPolicy = "default";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(Configuration["AppSettings:ConnectionString"]));
            services.AddControllers();
            services.AddAutoMapper(GetType().Assembly);
            services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicy, policy =>
                {
                    policy.WithOrigins(Configuration["AppSettings:ClientUrls"].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            #region services
            services.AddScoped<IHolidayRequestService, HolidayRequestService>();
            #endregion

            #region repositories
            services.AddScoped<IHolidayRequestRepository, HolidayRequestRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCors(DefaultCorsPolicy);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HolidayRequests}");
            });
        }
    }
}
