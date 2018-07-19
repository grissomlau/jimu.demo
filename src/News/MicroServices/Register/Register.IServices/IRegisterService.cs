using System;
using System.Threading.Tasks;
using Jimu;

namespace Register.IServices
{
    [JimuServiceRoute("/api/v1/register")]
    public interface IRegisterService : IJimuService
    {
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "check member name whether is valid")]
        bool CheckName(string name);
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "register member")]
        Task<bool> Register(string name, string nickname, string pwd);

    }
}
