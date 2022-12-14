using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Extensions
{
    public static class ServiceLifeTimeExtensions
    {
        public static ServiceLifetime ToServiceLifeTime(this string attribute) => attribute switch
        {
            "Transient" => ServiceLifetime.Transient,
            "Scoped" => ServiceLifetime.Scoped,
            "Singleton" => ServiceLifetime.Singleton,
            _ => ServiceLifetime.Transient
        };
    }
}
