using GetIt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetIt.Application.Builder
{
    public static class ServicesConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static IServiceCollection AddGetItApp(this IServiceCollection services)
        {
            services.AddGetItAppDb();
            return services;
        }
        public static IServiceCollection AddGetItAppDb(this IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("GetItAppDb");
            services.AddDbContextPool<GetItDbContext>(options =>
            {
                options.UseSqlServer(connectionString, c => c.MigrationsAssembly("GetIt.Data"));
            });
            return services;
        }
    }
}
