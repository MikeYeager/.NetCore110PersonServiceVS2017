using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace SampleVS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var config = new ConfigurationBuilder()
            //    .AddCommandLine(args)
            //    .AddEnvironmentVariables(prefix: "ASPNETCORE_")
            //    .Build();

            //var host = new WebHostBuilder()
            //    .UseConfiguration(config)
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseIISIntegration()
            //    .UseStartup<Startup>()
            //    .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
