using System;
using System.Collections.Generic;
using System.Text;
using Jimu;

namespace Auth.IServices
{
    public interface IAuthMemberService : IJimuService
    {
        MemberInfo GetMemberInfo(string username, string password);
    }
}
