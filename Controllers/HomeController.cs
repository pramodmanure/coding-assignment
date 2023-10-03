using MarketingCodingAssignment.Models;
using MarketingCodingAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketingCodingAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchEngine _searchEngine;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _searchEngine = new SearchEngine();
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public JsonResult Search(string searchString, int start, int rows, int? durationMinimum, int? durationMaximum, double? voteAverageMinimum)
        {
            SearchResultsViewModel searchResults = _searchEngine.Search(searchString, start, rows, durationMinimum, durationMaximum, voteAverageMinimum);
            return Json(new {searchResults});
        }

        [HttpPost]
        public void ReloadIndex()
        {
            DeleteIndex();
            PopulateIndex();
            return;
        }

        // Delete the contents of the lucene index 
        public void DeleteIndex()
        {
            _searchEngine.DeleteIndex();
            return;
        }

        // Read the data from the csv and feed it into the lucene index
        public void PopulateIndex()
        {
            _searchEngine.PopulateIndexFromCsv();
            return;
        }

    }
}

