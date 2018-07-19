using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway
{
    public class JimuOptions
    {
        public string ConsulIp { get; set; }
        public int ConsulPort { get; set; }
        public string ConsulServiceCategory { get; set; }
    }
}
