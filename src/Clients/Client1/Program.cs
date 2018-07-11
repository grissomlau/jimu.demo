using System;
using System.Linq;
using System.Threading;
using Autofac;
using Autofac.Core;
using IServices;
using Jimu;
using Jimu.Client;

namespace Client1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(1000);// waiting the server to start
            var containerBuilder = new ContainerBuilder();
            var hostBuilder = new Jimu.Client.ServiceHostClientBuilder(containerBuilder)
                    .UseLog4netLogger(new LogOptions { EnableConsoleLog = true })//use log4net to logger
                    .UsePollingAddressSelector()
                    .UseToken(() => null)
                    .UseInServerForDiscovery(new HttpAddress("127.0.0.1", 8001)) // use in memory modle for discoverying service, the ip and port are specified in the server;
                    .UseHttpForTransfer() // use http for transfer data between client and server
                    .UseServiceProxy(new[] { "IServices" })// use service proxy
                ;
            using (var host = hostBuilder.Build())
            {
                host.Run();
                var serviceProxy = host.Container.Resolve<IServiceProxy>();
                var userProxy = serviceProxy.GetService<IUserService>();
                var user = userProxy.GetById(1);
                Console.WriteLine();
                Console.WriteLine($"user name is {user.Name}");
                var result = userProxy.Add(new IServices.Models.User() { Id = 1, Name = "new user" });
                Console.WriteLine();
                Console.WriteLine($"added user id is {user.Name}");
                Console.ReadKey();
            }


        }
    }
}
