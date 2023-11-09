using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace mySite
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // Azure Blob ����, ����� ���� �޼���
                .ConfigureAppConfiguration((builderContext, config) =>
                {
                    Microsoft.Extensions.Hosting.IHostingEnvironment env =
                    (Microsoft.Extensions.Hosting.IHostingEnvironment)builderContext.HostingEnvironment;
                    config.AddJsonFile("storageSettings.json", optional: false, reloadOnChange: true);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
