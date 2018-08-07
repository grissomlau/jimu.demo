using System;
using System.Threading.Tasks;
using Jimu;

namespace Register.IServices
{
    [JimuServiceRoute("/api/v1/register")]
    public interface IRegisterService : IJimuService
    {
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "check member name whether is valid")]
        [JimuFieldComment("name", "用户名")]
        bool CheckName(string name);
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "register member")]
        [JimuFieldComment("name", "用户名")]
        [JimuFieldComment("nickname", "昵称")]
        [JimuFieldComment("pwd", "密码")]
        [JimuReturnComment("注册是否成功")]
        Task<bool> Register(string name, string nickname, string pwd);

    }
}
