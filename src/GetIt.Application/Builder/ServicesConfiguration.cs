using FluentValidation;
using GetIt.Application.Products;
using GetIt.Application.Products.Models;
using GetIt.Core.Attributes;
using GetIt.Core.Domain;
using GetIt.Core.Extensions;
using GetIt.Data;
using GetIt.Domain;
using GetIt.Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GetIt.Application.Builder
{
    public static class ServicesConfiguration
    {
        public static IConfiguration Configuration { get; set; }
        public static IServiceCollection AddGetItApp(this IServiceCollection services)
        {
            services.AddGetItAppDb();
            services.AddScoped<IDomainEventsDispatcher,DomainEventsDispatcher>();
            services.AddRepositories();
            services.AddMediatR(Assembly.Load("GetIt.Application"), Assembly.Load("GetIt.Domain"), Assembly.Load("GetIt.Core"), Assembly.Load("GetIt.Data"));
            services.AddMapper();
            services.AddMvc();
            services.AddValidatorsFromAssembly(Assembly.Load("GetIt.Application"));
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
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            var types = Assembly.Load("GetIt.Application").GetTypes().ToList();
            Add(services, types);
            return services;
        }
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps("GetIt.Application"));
            return services;
        }
        private static void Add(IServiceCollection services, List<Type> types)
        {
            var classes = types.Where(x => x.CustomAttributes != null);
            foreach (var implementType in classes)
            {
                var interfaceType = implementType.GetInterface("I" + implementType.Name);
                if (interfaceType != null)
                {
                    var toBeAdded = implementType.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(ScopedAttribute) || x.AttributeType == typeof(SingletonAttribute) || x.AttributeType == typeof(TransientAttribute));
                    if (toBeAdded != null)
                    {
                        var attribute = toBeAdded.AttributeType.Name.Replace("Attribute", "");
                        services.Add(new ServiceDescriptor(interfaceType, implementType, attribute.ToServiceLifeTime()));
                    }
                }
            }
        }
    }
}
