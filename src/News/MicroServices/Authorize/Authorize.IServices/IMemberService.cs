using System;
using System.Threading.Tasks;
using Jimu;

namespace Auth.IServices
{
    [JimuServiceRoute("/api/v1/member")]
    public interface IMemberService : IJimuService
    {
        [JimuService(EnableAuthorization = true, CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "get current token member info")]
        MemberInfo GetCurrentMemberInfo();
    }
}
