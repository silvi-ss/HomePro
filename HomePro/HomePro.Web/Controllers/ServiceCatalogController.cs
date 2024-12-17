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

        //
        //private readonly IServiceCatalogService serviceCatalogService;
        //private readonly IEnumerable<ServiceTypeViewModel> serviceTypes;

        //public ServiceCatalogController(IServiceCatalogService serviceCatalogService)
        //    : base()
        //{
        //    this.serviceCatalogService = serviceCatalogService;
        //    this.serviceTypes = this.serviceCatalogService.GetServiceTypes().ToList();
        //}

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

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var service = await serviceCatalogService.GetServiceByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            var model = new ServiceCatalogFormModel
            {
                //Name = service.Name,
                //Description = service.Description,
                //ServiceTypeId = (int)service.Type,
                //ImageName = !string.IsNullOrEmpty(service.Image)
                //? Path.GetFileName(service.Image)
                //: null, // Предпазване от null
                //ServiceTypes = serviceCatalogService.GetServiceTypes() // Зареждане на типовете услуги
            };

            return View(model);
        }




        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(Guid id, ServiceCatalogFormModel model, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                model.ServiceTypes = serviceCatalogService.GetServiceTypes();
                return View(model);
            }

            try
            {
                var success = await serviceCatalogService.UpdateServiceAsync(id, model);

                if (!success)
                {
                    return NotFound();
                }

                TempData["SuccessMessage"] = "Service updated successfully!";
                return RedirectToAction("Details", "ServiceCatalog", new { id });
            }
            catch
            {
                ModelState.AddModelError("", "An error occurred while updating the service.");
                model.ServiceTypes = serviceCatalogService.GetServiceTypes();
                return View(model);
            }
        }




    }
}
