using Jimu;
using System;

namespace JustServices
{
    [JimuServiceRoute("api/{Service}")]//指定 rpc 调用路径
    public class UserService : IJimuService
    {
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-06-05", Comment = "get user by userid")]
        public string GetById(int userId)
        {
            return "hah";

        }

    }
}
