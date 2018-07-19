using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auth.IServices;
using Jimu;

namespace Auth.Services
{
    public class AuthMemberService : IAuthMemberService
    {
        static List<MemberInfo> _membersDb = new List<MemberInfo>();
        readonly ILogger _logger;
        public AuthMemberService(ILogger logger)
        {
            _logger = logger;
        }

        static AuthMemberService()
        {
            // mock some member 
            _membersDb.Add(new MemberInfo { Id = Guid.NewGuid().ToString(), Name = "grissom", NickName = "Gil", Role = "admin" });
            _membersDb.Add(new MemberInfo { Id = Guid.NewGuid().ToString(), Name = "foo", NickName = "Fo", Role = "guest" });
        }

        public MemberInfo GetMemberInfo(string username, string password)
        {
            var member = _membersDb.FirstOrDefault(x => x.Name == username && "123" == password);

            _logger.Debug($"username: {username}, found {(member == null ? "no " : "")} member.");

            return member;
        }
    }
}
