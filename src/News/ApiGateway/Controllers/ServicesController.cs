using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Jimu;
using Jimu.Client;
using Jimu.Client.ApiGateway;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    //[Produces("application/json")]
    public class ServicesController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet(Name ="services")]
        public async Task<List<JimuServiceDesc>> GetServices(string server)
        {
            var serviceDiscovery = JimuClient.Host.Container.Resolve<IClientServiceDiscovery>();
            var routes = await serviceDiscovery.GetRoutesAsync();
            if (routes != null && routes.Any() && !string.IsNullOrEmpty(server))
            {
                return (from route in routes
                        where route.Address.Any(x => x.Code == server)
                        select route.ServiceDescriptor).ToList();
            }
            return (from route in routes select route.ServiceDescriptor).ToList();

        }


    }
}