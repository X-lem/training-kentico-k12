using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.Search;

namespace MedioClinic.Models.SearchResult
{
    public class SearchResultModel : IViewModel
    {
        public string Query { get; set; }
        public List<TreeNode> SearchResultPages { get; set; }
    }
}