using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jimu;

namespace News.IServices
{
    public class NewsService : INewsService
    {
        readonly ILogger _logger;
        readonly JimuPayload _jimuPayload;
        static List<News> _newsDb = new List<News>();
        static NewsService()
        {
            // mock some  news
            _newsDb.Add(new News { Id = new Guid().ToString(), Director = "grissom", PostTime = DateTime.Now.ToString(), Title = "世界杯：法国夺冠啦！", Content = "头条：法国勇夺2018年世界杯冠军， 后面省略 1 万字" });
            _newsDb.Add(new News { Id = new Guid().ToString(), Director = "grissom", PostTime = DateTime.Now.ToString(), Title = "Jimu 发布新版本", Content = "新闻社：Jimu(积木) 发布新版本，特点有，后面省略 1 万字" });
        }
        public NewsService(ILogger logger, JimuPayload jimuPayload)
        {
            _logger = logger;
            _jimuPayload = jimuPayload;
        }

        public Task<List<News>> GetAllNews()
        {
            _logger.Debug($"member: {_jimuPayload.Items["username"]} getallnews");
            return Task.FromResult(_newsDb);
        }

        public Task<string> PostNews(News news)
        {
            _logger.Debug($"member: {_jimuPayload.Items["username"]} post an news which title is: {news.Title}");

            news.PostTime = DateTime.Now.ToString();
            news.Id = new Guid().ToString();
            news.Director = _jimuPayload.Items["username"].ToString();
            _newsDb.Add(news);
            return Task.FromResult(news.Id);

        }

        public News GetNews(string id)
        {
            _logger.Debug($"member: {_jimuPayload.Items["username"]} getnews by id: {id}");
            var news = _newsDb.FirstOrDefault(x => x.Id == id);
            return news;
        }
    }
}
