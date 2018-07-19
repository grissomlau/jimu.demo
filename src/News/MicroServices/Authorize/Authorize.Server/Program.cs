using System;
using Autofac;
using Jimu;
using Jimu.Server;
using Jimu.Server.OAuth;
using Auth.IServices;

namespace Auth.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceHost host = null;

            var builder = new ServiceHostServerBuilder(new ContainerBuilder())
             .UseLog4netLogger()
             .LoadServices("Auth.IServices", "Auth.Services")
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
                     var memberService = host.Container.Resolve<IAuthMemberService>();

                     var member = memberService.GetMemberInfo(ctx.UserName, ctx.Password);
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
                host.Run();
                while (true)
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
