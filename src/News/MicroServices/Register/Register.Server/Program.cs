using Jimu.Server;
using System;

namespace Register.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ServiceHostServerBuilder(new Autofac.ContainerBuilder())
             .UseLog4netLogger()
             .LoadServices(new string[] { "Register.IServices", "Register.Services" })
             .UseDotNettyForTransfer("127.0.0.1", 8001)
             .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService", $"127.0.0.1:8001")
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
