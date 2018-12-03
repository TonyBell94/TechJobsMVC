using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }
        
        public IActionResult Results(string SearchType, string SearchTerm)
        {
        if (SearchType == "all")
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(SearchTerm);
                ViewBag.jobs = jobs;
            }
        else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(SearchType, SearchTerm);
                ViewBag.jobs = jobs;
            }

            ViewBag.columns = ListController.columnChoices;

            return View("Views/Search/Index.cshtml");
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
