using Jimu;
using System;

namespace QuickStart.Services
{
    /// <summary>
    /// 用户
    /// </summary>
    [JimuServiceRoute("api/{Service}")] // RPC 调用路径
    public class UserService : IJimuService
    {
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JimuService(CreatedBy = "grissom")] // 指定服务的元数据, 该服务调用路径为 api/user/getname?id=
        public string GetName(string id)
        {
            return $"user id {id}, name enjoy!";
        }
    }
}
