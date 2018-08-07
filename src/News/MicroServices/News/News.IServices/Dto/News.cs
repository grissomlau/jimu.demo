using System;
using System.Collections.Generic;
using System.Text;
using Jimu;

namespace News.IServices
{
    public class News
    {
        [JimuFieldComment("新闻id")]
        public string Id { get; set; }
        [JimuFieldComment("新闻标题")]
        public string Title { get; set; }
        [JimuFieldComment("作者")]
        public string Director { get; set; }
        [JimuFieldComment("发布时间")]
        public string PostTime { get; set; }
        [JimuFieldComment("新闻内容")]
        public string Content { get; set; }

    }
}
