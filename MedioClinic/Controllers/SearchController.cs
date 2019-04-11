using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Business.DependencyInjection;
using CMS.DocumentEngine;
using CMS.Membership;
using CMS.Search;
using MedioClinic.Controllers;
using MedioClinic.Models.SearchResult;

namespace MedioClinic.Controllers
{
    public class SearchController : BaseController
    {
        // Adds the smart search indexes that will be used to perform searches
        public static readonly string[] searchIndexes = new string[] { "MedioClinic.Index" };
        // Sets the limit of items per page of search results
        private const int PAGE_SIZE = 10;

        public SearchController(
            IBusinessDependencies dependencies
            ) : base(dependencies) { }

        /// <summary>
        /// Performs a search and displays its result.
        /// </summary>
        [ValidateInput(false)]
        public ActionResult SearchIndex(string searchText)
        {
            // Displays the search page without any search results if the query is empty
            if (String.IsNullOrWhiteSpace(searchText))
            {
                // Creates a model representing empty search results
                SearchResultModel emptyModel = new SearchResultModel
                {
                    Query = String.Empty,
                    SearchResultPages = new List<TreeNode>()
                };

                return View(emptyModel);
            }

            // Searches the specified index and gets the matching results
            SearchParameters searchParameters = SearchParameters.PrepareForPages(searchText, searchIndexes, 1, PAGE_SIZE, MembershipContext.AuthenticatedUser, "en-us", true);
            SearchResult searchResult = SearchHelper.Search(searchParameters);

            List<TreeNode> pageLists = new List<TreeNode>();
            TreeProvider tp = new TreeProvider();

            // Get pages for 
            foreach (var item in searchResult.Items)
            {
                var node = tp.SelectSingleDocument(item.Data.GetIntegerValue("DocumentID", 0));

                if (node != null)
                {
                    pageLists.Add(node);
                }
            }

            var model = GetPageViewModel(new SearchResultModel()
            {
                Query = searchText,
                SearchResultPages = pageLists
            }, searchText);

            return View(model);
        }
    }
}