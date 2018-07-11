using Jimu;
using System;

namespace QuickStart.Services
{
    [JimuServiceRoute("api/{Service}")] // RPC 调用路径
    public class UserService : IJimuService
    {
        [JimuService(CreatedBy = "grissom")] // 指定服务的元数据, 该服务调用路径为 api/user/getname?id=
        public string GetName(string id)
        {
            return $"user id {id}, name enjoy!";
        }
    }
}
