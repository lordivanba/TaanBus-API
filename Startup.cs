using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taanbus.Domain.Interfaces;
using taanbus.Infrastructure.Data;
using taanbus.Infrastructure.Repositories;

namespace taanbus
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
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("*");
                                });
            });
            services.AddCors();
            services.AddControllers();

            //Database connection
            services.AddDbContext<taanbusdbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("taanbusdb")));

            //Interfaces
            services.AddTransient<ISugerenciaSqlRepository, SugerenciaSqlRepository>();
            services.AddTransient<IQuejaSqlRepository, QuejaSqlRepository>();
             services.AddTransient<IUsuarioSqlRepository, UsuarioSqlRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Login
            services.AddScoped<System.Net.Http.HttpClient>();

            //Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("MyAllowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // endpoints.MapBlazorHub();
                // endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
