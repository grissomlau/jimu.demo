using System;
using System.Collections.Generic;
using System.Text;
using Jimu;

namespace Auth.IServices
{
    [JimuServiceRoute("/api/v1/auth")]
    public interface IAuthMemberService : IJimuService
    {
        [JimuService()]
        MemberInfo GetMemberInfo(string username, string password);
    }
}
