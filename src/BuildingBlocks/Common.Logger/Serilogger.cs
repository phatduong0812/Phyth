using Microsoft.Extensions.Hosting;
using Serilog;

namespace Common.Logger
{
    public static class Serilogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
            (context, configuation) =>
            {
                var applicationName = context.HostingEnvironment.ApplicationName.ToLower().Replace(".", ",");
                var environmentName = context.HostingEnvironment.EnvironmentName ?? "Development";

                configuation
                    .WriteTo.Debug()
                    .WriteTo.Console(outputTemplate:
                        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("EnviromentName", environmentName)
                    .Enrich.WithProperty("ApplicationName", applicationName)
                    .ReadFrom.Configuration(context.Configuration);
            };
    }
}