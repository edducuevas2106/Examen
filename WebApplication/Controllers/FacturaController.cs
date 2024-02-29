using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ILogger<FacturaController> _logger;

        public FacturaController(ILogger<FacturaController> logger)
        {
            _logger = logger;
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
    }
}
