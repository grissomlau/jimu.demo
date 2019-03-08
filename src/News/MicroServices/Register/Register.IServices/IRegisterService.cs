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
        /// <summary>
        /// register member
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="nickname">昵称</param>
        /// <param name="pwd">密码</param>
        /// <returns>注册是否成功</returns>
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-07-17")]
        Task<bool> Register(string name, string nickname, string pwd);

    }
}
