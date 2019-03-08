using System;
using Autofac;
using Jimu;
using Jimu.Server;
using Jimu.Server.OAuth;
using Auth.IServices;
using Jimu.Client;

namespace Auth.Server
{
    class Program
    {
        static IAuthMemberService _authMemberService;

        static void Main(string[] args)
        {
            IServiceHost host = null;

            // register as server
            var builder = new ServiceHostServerBuilder(new ContainerBuilder())
             .UseLog4netLogger()
             .LoadServices(new string[] { "Auth.IServices", "Auth.Services" })
             .UseDotNettyForTransfer("127.0.0.1", 8000)
             .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService", $"127.0.0.1:8000")
             .UseJoseJwtForOAuth<DotNettyAddress>(new JwtAuthorizationOptions
             {
                 SecretKey = "123456",
                 ExpireTimeSpan = new TimeSpan(3, 0, 0, 0),
                 ValidateLifetime = true,
                 ServerIp = "127.0.0.1",
                 ServerPort = 8000,
                 TokenEndpointPath = "api/oauth/token?username=&password=",
                 CheckCredential = new Action<JwtAuthorizationContext>(ctx =>
                 {
                     //var memberService = host.Container.Resolve<IAuthMemberService>();

                     _authMemberService = new Auth.Services.AuthMemberService(new NLogger());
                     var member = _authMemberService.GetMemberInfo(ctx.UserName, ctx.Password);
                     if (member == null)
                     {
                         ctx.Rejected("username or password is incorrect.", "");
                     }
                     else
                     {
                         ctx.AddClaim("roles", member.Role);
                         ctx.AddClaim("member", Newtonsoft.Json.JsonConvert.SerializeObject(member));

                     }
                 }),
             });
            using (host = builder.Build())
            {
                //InitProxyService();
                host.Run();
                while (true)
                {
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// register as client 
        /// </summary>
        static void InitProxyService()
        {
            var containerBuilder = new ContainerBuilder();
            var host = new Jimu.Client.ServiceHostClientBuilder(containerBuilder)
                //.UseLog4netLogger(new LogOptions { EnableConsoleLog = true })
                .UsePollingAddressSelector()
                .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService")
                .UseDotNettyForTransfer()
                .UseHttpForTransfer()
                .UseServiceProxy(new[] { "Auth.IServices" })
                .Build()
                ;
            host.Run();
            var proxy = host.Container.Resolve<IServiceProxy>();
            _authMemberService = proxy.GetService<IAuthMemberService>();
        }
    }
}
