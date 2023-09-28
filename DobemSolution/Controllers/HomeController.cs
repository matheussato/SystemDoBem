using DobemSolution.Models;
using DobemSolution.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;

namespace DobemSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OracleDbContext _oracleDbContext;

        public HomeController(ILogger<HomeController> logger, OracleDbContext oracleDbContext)
        {
            _logger = logger;
            _oracleDbContext = oracleDbContext;
        }

        public IActionResult Index()
        {
            ViewData["feedbacks"] = _oracleDbContext
                .Feedback
                .Include(x => x.Curso)
                .Where(x => x.autorizacao & x.estrelas >= 3)
                .Take(5);

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