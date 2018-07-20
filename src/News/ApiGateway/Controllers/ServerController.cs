using Autofac;
using Jimu;
using Jimu.Client;
using Jimu.Client.ApiGateway;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGateway.Controllers
{
    public class ServerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet(Name ="addresses")]
        public async Task<List<JimuAddress>> GetAddresses()
        {
            var serviceDiscovery = JimuClient.Host.Container.Resolve<IClientServiceDiscovery>();
            var addresses = await serviceDiscovery.GetAddressAsync();
            return addresses;

        }

    }
}