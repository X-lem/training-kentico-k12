using Business.Dto.Articles;
using CMS.CustomTables;
using Kentico.Forms.Web.Mvc;
using System.Collections.Generic;

namespace MedioClinic.Models.Articles
{
    public class ArticleDetailViewModel : IViewModel
    {
        public ArticleDto Article { get; set; }
        public List<CustomTableItem> Authors { get; set; }
        public List<CustomTableItem> CalloutAds { get; set; }
    }
}