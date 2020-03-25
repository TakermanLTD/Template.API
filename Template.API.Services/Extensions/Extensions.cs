using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.API.Data.Contexts;

namespace Template.API.Services.Extensions
{
    public static class Extensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Context>(x => config.GetConnectionString("Template.API"));
        }
    }
}