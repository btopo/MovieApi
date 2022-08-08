using CreatingAMovieLab.DAL;
using CreatingAMovieLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatingAMovieLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesContext _moviesContext;



        public HomeController(ILogger<HomeController> logger, MoviesContext moviesContext)
        {
            _logger = logger;
            _moviesContext = moviesContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}