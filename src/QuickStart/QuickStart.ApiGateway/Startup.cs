using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Jimu.Client;
using Jimu.Client.ApiGateway;
using Autofac;

namespace QuickStart.ApiGateway
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
            services.UseJimuSwagger(new Jimu.Client.ApiGateway.SwaggerIntegration.JimuSwaggerOptions("CTAUTO API"));
            services.UseJimu();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJimuSwagger();

            // jimu client


            var host = new ApplicationClientBuilder(new ContainerBuilder()).Build();

            app.UseJimu(host);
            host.Run();
        }
    }
}
