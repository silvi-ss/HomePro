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

		[AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await serviceCatalogService.GetAllServicesAsync();

            return View(services);
        }


		[Authorize]
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Add(ServiceCatalogFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await serviceCatalogService.AddServiceAsync(model);

				TempData["SuccessMessage"] = "Service added successfully!";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("", "An error occurred while adding the service.");
				return View(model);
			}
		}
	}
}
