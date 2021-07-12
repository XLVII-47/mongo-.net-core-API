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
using Microsoft.OpenApi.Models;
using BranchsApi.Models;
using Microsoft.Extensions.Options;

using BranchsApi.Services;
using Microsoft.AspNetCore.Http;

namespace BranchsApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.Configure<BranchDatabaseSettings>(
        Configuration.GetSection(nameof(BranchDatabaseSettings)));

            services.AddSingleton<IBranchDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BranchDatabaseSettings>>().Value);

            services.AddSingleton<BranchService>();

            services.Configure<LayerDatabaseSettings>(
        Configuration.GetSection(nameof(LayerDatabaseSettings)));

            services.AddSingleton<ILayerDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<LayerDatabaseSettings>>().Value);

            services.AddSingleton<LayerService>();


            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:44333").AllowAnyHeader().AllowAnyMethod();
                                  });
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BranchsApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BranchsApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                /*
                endpoints.MapGet("/layer",
                context => context.Response.WriteAsync("layer"))
                .RequireCors(MyAllowSpecificOrigins);
                */
                endpoints.MapControllers().RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
