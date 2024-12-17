using HomePro.Services.Data;
using HomePro.Services.Data.Interfaces;
using HomePro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomePro.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceCatalogService _serviceCatalogService;

       
        public HomeController(ILogger<HomeController> logger, IServiceCatalogService serviceCatalogService)
        {
            _logger = logger;
            _serviceCatalogService = serviceCatalogService;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceCatalogService.GetAllServicesAsync();

            if (!services.Any())
            {
                Console.WriteLine("No services found."); 
            }

            return View(services);
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
