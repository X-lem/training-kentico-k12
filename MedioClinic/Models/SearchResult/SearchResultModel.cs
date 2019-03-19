using System.Collections.Generic;
using CMS.Search;

namespace MedioClinic.Models.SearchResult
{
    public class SearchResultModel : IViewModel
    {
        public string Query { get; set; }

        public IEnumerable<SearchResultItem> Items { get; set; }
    }
}