using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Template.API.Services.Extensions;
using Template.API.Services.Repositories;
using Template.API.Services.Repositories.Contracts;
using Template.API.Services.Services;
using Template.API.Services.Services.Contracts;
using System;

namespace Template.API.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureContext(Configuration);

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IExampleRepository, ExampleRepository>();

            services.AddScoped<IExampleService, ExampleService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Takerman Dating API",
                    Description = "Takerman Dating API",
                    Contact = new OpenApiContact
                    {
                        Name = "Tanyo Ivanov",
                        Email = string.Empty,
                        Url = new Uri("http://tanyo.takerman.net"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

#if DEBUG
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examples API V1");
                c.RoutePrefix = string.Empty;
            });
#endif

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