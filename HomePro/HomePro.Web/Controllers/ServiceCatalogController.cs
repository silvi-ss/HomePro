using HomePro.Services.Data.Interfaces;
using HomePro.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HomePro.Web.ViewModels;

using Microsoft.AspNetCore.Authorization;
using HomePro.Web.ViewModels.ServiceCatalog;

namespace HomePro.Web.Controllers
{
    public class ServiceCatalogController : BaseController
    {
        private readonly IServiceCatalogService serviceCatalogService;

        public ServiceCatalogController(IServiceCatalogService serviceCatalogService)
            : base()
        {
            this.serviceCatalogService = serviceCatalogService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await serviceCatalogService.GetAllServicesAsync();

            return View(services);
        }

    }
}
