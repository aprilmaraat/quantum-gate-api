using Microsoft.AspNetCore.Hosting;
using QuantumGateAPI.Services;

namespace QuantumGateAPI
{
    public class Program
    {public static void Main(string[] args)
        {
            Console.Title = "Quarto.Auth";
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}