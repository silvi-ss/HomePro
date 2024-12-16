using HomePro.Data.Models;
using HomePro.Data.Models.Enums;
using HomePro.Data.Repository.Interfaces;
using HomePro.Services.Data.Interfaces;
using HomePro.Web.ViewModels.ServiceCatalog;
using Microsoft.EntityFrameworkCore;

namespace HomePro.Services.Data
{
    public class ServiceCatalogService : IServiceCatalogService
    {
        private readonly IRepository<ServiceCatalog, Guid> serviceCatalogRepository;

        public ServiceCatalogService(IRepository<ServiceCatalog, Guid> serviceCatalogRepository)
        {
            this.serviceCatalogRepository = serviceCatalogRepository;
        }

        public async Task<IEnumerable<ServiceCatalogIndexViewModel>> GetAllServicesAsync()
        {
            var allServices = await this.serviceCatalogRepository
                .GetAllAttached()
                .Where(s => !s.IsDeleted)
                .Select(s => new ServiceCatalogIndexViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    Image = s.Image ?? "default.png",
                    Type = s.Type.ToString()
                })
                .ToListAsync();

            return allServices;
        }

        public async Task<bool> AddServiceAsync(ServiceCatalogFormModel model)
        {
            var service = new ServiceCatalog
            {
                Name = model.Name,
                Description = model.Description,
                Type = (ServiceType)model.ServiceTypeId,
                Image = model.Image
            };

            await serviceCatalogRepository.AddAsync(service);

            return true;
        }


        public IEnumerable<ServiceTypeViewModel> GetServiceTypes()
        {
            return Enum.GetValues<ServiceType>()
                .Select(t => new ServiceTypeViewModel
                {
                    Id = (int)t,
                    Name = t.ToString()
                });
        }
    }
}
	