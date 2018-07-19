using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Autofac;
using Jimu;
using Jimu.Client;
using Jimu.Client.ApiGateway;

namespace ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.UseJimu();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseStatusCodePages();

            // jimu client
            var host = new ServiceHostClientBuilder(new ContainerBuilder())
                .UseLog4netLogger(new LogOptions
                {
                    EnableConsoleLog = true,
                    EnableFileLog = true,
                    FileLogLevel = LogLevel.Info | LogLevel.Error,
                })
                .UseConsulForDiscovery("127.0.0.1", 8500, "JimuService")
                .UseDotNettyForTransfer()
                .UseHttpForTransfer()
                .UsePollingAddressSelector()
                .UseServerHealthCheck(1)
                .SetRemoteCallerRetryTimes(3)
                .SetDiscoveryAutoUpdateJobInterval(1)
                .UseToken(() => { var headers = JimuHttpContext.Current.Request.Headers["Authorization"]; return headers.Any() ? headers[0] : null; })
                .Build();
            app.UseJimu(host);
            host.Run();
        }
    }
}
