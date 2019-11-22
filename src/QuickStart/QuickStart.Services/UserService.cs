using Jimu;
using System;

namespace QuickStart.Services
{
    /// <summary>
    /// 用户
    /// </summary>
    [Jimu] // RPC 调用路径
    public class UserService : IJimuService
    {
        /// <summary>
        /// 获取用户名称2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JimuGet("/name/{id}", true)]
        public string GetName(string id)
        {
            return $"user id {id}, name enjoy!";
        }
    }
}
