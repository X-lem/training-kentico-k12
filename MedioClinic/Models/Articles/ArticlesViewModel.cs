using System.Collections.Generic;
using Business.Dto.Articles;

namespace MedioClinic.Models.Articles
{
    public class ArticlesViewModel : IViewModel
    {
        public ArticleSectionDto ArticleSection { get; set; }
        public  IEnumerable<ArticleDto> Articles { get; set; }
    }
}