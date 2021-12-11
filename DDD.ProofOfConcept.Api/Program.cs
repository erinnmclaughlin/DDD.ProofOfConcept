using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DDD.ProofOfConcept.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

            return hostBuilder;
        }
            
    }
}
