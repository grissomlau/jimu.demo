using System;
using Jimu.Server;

namespace QuickStart.Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new ServiceHostServerBuilder(new Autofac.ContainerBuilder())
                .UseLog4netLogger()
                .LoadServices(new string[] { "QuickStart.Services" })
                .UseDotNettyForTransfer("127.0.0.1", 8001)
                .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService", $"127.0.0.1:8001")
                ;
            using (var host = hostBuilder.Build())
            {
                host.Run();
                Console.ReadLine();
            }

        }
    }
}
