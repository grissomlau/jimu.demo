using Jimu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.IServices
{
    public class MemberService : IMemberService
    {
        readonly ILogger _logger;
        readonly JimuPayload _jimuPayload;
        public MemberService(ILogger logger, JimuPayload jimuPayload)
        {
            _logger = logger;
            _jimuPayload = jimuPayload;
        }

        public MemberInfo GetCurrentMemberInfo()
        {
            _logger.Debug($"current token member username: {_jimuPayload.Items["username"]}");

            return Newtonsoft.Json.JsonConvert.DeserializeObject<MemberInfo>(_jimuPayload.Items["member"].ToString());
        }


    }
}
