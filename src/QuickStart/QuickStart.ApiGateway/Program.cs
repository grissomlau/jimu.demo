using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace QuickStart.ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Jimu.Client.ApplicationWebClient.Instance.Run();
        }
    }
}
