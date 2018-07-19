using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jimu;

namespace News.IServices
{
    [JimuServiceRoute("/api/v1/news")]
    public interface INewsService : IJimuService
    {
        [JimuService(EnableAuthorization = true, CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "get all news")]
        Task<List<News>> GetAllNews();

        [JimuService(EnableAuthorization = true, Roles = "admin", CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "post news")]
        Task<string> PostNews(News news);

        [JimuService(EnableAuthorization = true, CreatedBy = "grissom", CreatedDate = "2018-07-17", Comment = "get specify news")]
        News GetNews(string id);
    }
}
