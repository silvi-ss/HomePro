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
        public IActionResult ServiceTypes()
        {
            var serviceTypes = serviceCatalogService.GetServiceTypes();

            return View(serviceTypes);
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
            var model = new ServiceCatalogFormModel
            {
                ServiceTypes = serviceCatalogService.GetServiceTypes()
            };

            return View(model);
        }

		[Authorize]
		[HttpPost]
        public async Task<IActionResult> Add(ServiceCatalogFormModel model, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                model.ServiceTypes = serviceCatalogService.GetServiceTypes();
                return View(model);
            }

            try
            {
                if (imageFile != null)
                {
                    // read the file and convert it in byte[]
                    using (var memoryStream = new MemoryStream())
                    {
                        await imageFile.CopyToAsync(memoryStream);
                        model.ImageData = memoryStream.ToArray(); // file content
                        model.ImageName = Path.GetFileName(imageFile.FileName); // file name
                    }
                }
                               
                await serviceCatalogService.AddServiceAsync(model);

                TempData["SuccessMessage"] = "Service added successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while adding the service.");
                model.ServiceTypes = serviceCatalogService.GetServiceTypes();
                return View(model);
            }
        }
	}
}
