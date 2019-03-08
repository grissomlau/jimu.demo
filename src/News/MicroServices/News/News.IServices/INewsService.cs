using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jimu;

namespace News.IServices
{
    [JimuServiceRoute("/api/v1/news")]
    public interface INewsService : IJimuService
    {
        /// <summary>
        /// get all news
        /// </summary>
        /// <returns></returns>
        [JimuService(EnableAuthorization = true, CreatedBy = "grissom", CreatedDate = "2018-07-17")]
        Task<List<News>> GetAllNews();

        /// <summary>
        /// post news
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        [JimuService(EnableAuthorization = true, Roles = "admin", CreatedBy = "grissom", CreatedDate = "2018-07-17")]
        Task<string> PostNews(News news);

        /// <summary>
        /// 根据新闻 id 获取新闻内容
        /// </summary>
        /// <param name="id">新闻id</param>
        /// <returns>一篇新闻内容</returns>
        [JimuService(EnableAuthorization = true, CreatedBy = "grissom", CreatedDate = "2018-07-17")]
        //[JimuFieldComment("id", "新闻id")]
        //[JimuReturnComment("一篇新闻内容")]
        News GetNews(string id);
    }
}
