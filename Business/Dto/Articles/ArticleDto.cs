using CMS.DocumentEngine;
using System;

namespace Business.Dto.Articles
{
    public class ArticleDto
    {
        public int NodeId { get; set; }
        public Guid NodeGuid { get; set; }
        public string NodeAlias { get; set; }
        public DateTime DatePublished { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Authors { get; set; }
        public DocumentAttachment Thumbnail { get; set; }
    }
}