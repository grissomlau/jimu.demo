using System;
using System.Collections.Generic;
using System.Text;
using Jimu;

namespace News.IServices
{
    public class News
    {
        /// <summary>
        /// 新闻id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string PostTime { get; set; }
        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content { get; set; }

    }
}
