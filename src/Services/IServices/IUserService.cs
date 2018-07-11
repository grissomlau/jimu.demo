using IServices.Models;
using System;
using Jimu;

namespace IServices
{
    [JimuServiceRoute("api/{Service}")]//指定 rpc 调用路径
    public interface IUserService : IJimuService
    {
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-06-05", Comment = "get user by userid")]
        User GetById(int userId);
        [JimuService(CreatedBy = "grissom", CreatedDate = "2018-06-05", Comment = "add user")]
        int Add(User user);
    }
}
