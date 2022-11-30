using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Data
{
    public class Initializer
    {
        public static void InitDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                GetItDbContext getItDbContext = serviceScope.ServiceProvider.GetRequiredService<GetItDbContext>();
                if (getItDbContext.Database.GetPendingMigrations().Any())
                {
                    getItDbContext.Database.Migrate();
                }

                //initial data 
                if (!getItDbContext.AppUsers.Any())
                {
                    getItDbContext.AppUsers.Add(new Domain.Users.AppUser("admin", "user", "admin", "123456"));
                }
                getItDbContext.SaveChanges();
            }
        }
    }
}
