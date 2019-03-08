using System;
using Autofac;
using Jimu.Server;

namespace News.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ServiceHostServerBuilder(new ContainerBuilder())
             .UseLog4netLogger()
             .LoadServices(new string[] { "News.IServices", "News.Services" })
             .UseDotNettyForTransfer("127.0.0.1", 8002)
             .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService", $"127.0.0.1:8002")
             .UseJoseJwtForOAuth<Jimu.DotNettyAddress>(new Jimu.Server.OAuth.JwtAuthorizationOptions
             {
                 SecretKey = "123456",
             });
            using (var host = builder.Build())
            {
                host.Run();
                while (true)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
