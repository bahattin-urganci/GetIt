using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GetIt.Core.Logging
{
    public static class Configuration
    {
        public static IHostBuilder UseGetitLogger(this IHostBuilder hostBuilder, Action<HostBuilderContext, IServiceProvider, LoggerConfiguration> configuration)
        {
            hostBuilder.UseSerilog(configuration);
            return hostBuilder;
        }
        public static LoggerConfiguration Configure(HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration.ReadFrom.Configuration(context.Configuration).ReadFrom.Services(services);
            
            string outputTemplate = "[{Timestamp:HH:mm:ss.fff zzz} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}";
            foreach (LogEventLevel level in Enum.GetValues(typeof(LogEventLevel)))
            {
                loggerConfiguration.WriteTo.Logger(x => x.Filter.ByIncludingOnly(e => e.Level == level).WriteTo.File(path: Path.Combine("logs", $"log-{level.ToString().ToLower()}.txt"),
                    fileSizeLimitBytes: 10 * (1024 * 1024),
                    rollOnFileSizeLimit: true,
                    outputTemplate: outputTemplate,
                    rollingInterval: RollingInterval.Day
                    )).Enrich.FromLogContext();
            }
            loggerConfiguration.WriteTo.Console(LogEventLevel.Verbose, outputTemplate: outputTemplate, theme: Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme.Code);
            return loggerConfiguration;
        }
    }
}
