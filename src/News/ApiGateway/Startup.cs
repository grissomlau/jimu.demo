using System.Linq;
using System.Text;
using Autofac;
using ApiGateway.Model;
using Jimu.Client;
using Jimu.Client.ApiGateway;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Jimu;

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

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();

            // jimu client
            var jimuOptions = Configuration.GetSection("JimuOptions").Get<JimuOptions>();
            var host = new ServiceHostClientBuilder(new ContainerBuilder())
                .UseLog4netLogger(new LogOptions
                {
                    EnableConsoleLog = true,
                    EnableFileLog = true,
                    FileLogLevel = LogLevel.Info | LogLevel.Error,
                })
                .UseConsulForDiscovery(jimuOptions.ConsulIp, jimuOptions.ConsulPort, jimuOptions.ConsulServiceCategory)
                .UseDotNettyForTransfer()
                .UseHttpForTransfer()
                .UsePollingAddressSelector()
                .UseServerHealthCheck(1)
                .SetDiscoveryAutoUpdateJobInterval(1)
                .UseToken(() => { var headers = JimuHttpContext.Current.Request.Headers["Authorization"]; return headers.Any() ? headers[0] : null; })
                .Build();
            app.UseJimu(host);
            host.Run();
        }
    }
}
