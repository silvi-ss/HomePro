//using HomePro.Data.Models;
//using HomePro.Data.Models.Enums;
//using HomePro.Data.Repository.Interfaces;
//using HomePro.Services.Data.Interfaces;
//using HomePro.Web.ViewModels.ServiceCatalog;
//using Microsoft.EntityFrameworkCore;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace HomePro.Services.Data
//{
//    public class ServiceCatalogService : IServiceCatalogService
//    {
//        private readonly IRepository<ServiceCatalog, Guid> serviceCatalogRepository;

//        public ServiceCatalogService(IRepository<ServiceCatalog, Guid> serviceCatalogRepository)
//        {
//            this.serviceCatalogRepository = serviceCatalogRepository;
//        }

//        //public async Task<IEnumerable<ServiceCatalogIndexViewModel>> GetAllServicesAsync()
//        //{
//        //    var services = await serviceCatalogRepository
//        //       .GetAllAttached()
//        //       .Where(s => !s.IsDeleted) 
//        //       .Distinct()  
//        //       .Select(s => new ServiceCatalogIndexViewModel
//        //       {
//        //           Id = s.Id,
//        //           Name = s.Name,
//        //           Description = s.Description,
//        //           Image = s.Image ?? "/images/default-service.jpg",
//        //           Type = s.Type.ToString()
//        //       })
//        //       .ToListAsync();

//        //    return services;
//        //}

//        public async Task<bool> AddServiceAsync(ServiceCatalogFormModel model)
//        {
//            var service = new ServiceCatalog
//            {
//                Name = model.Name,
//                Description = model.Description,
//                Type = (ServiceType)model.ServiceTypeId
//            };

//            if (model.ImageData != null && !string.IsNullOrEmpty(model.ImageName))
//            {
//                var fileName = $"{Guid.NewGuid()}_{model.ImageName}";
//                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

//                // save file in folder
//                await File.WriteAllBytesAsync(filePath, model.ImageData);

//                // save path
//                service.Image = $"/images/{fileName}";
//            }

//            await serviceCatalogRepository.AddAsync(service);
//            return true;
//        }

//        public async Task<bool> UpdateServiceAsync(Guid id, ServiceCatalogFormModel model)
//        {
//            var service = await serviceCatalogRepository.GetByIdAsync(id);

//            if (service == null)
//            {
//                return false;
//            }

           
//            service.Name = model.Name;
//            service.Description = model.Description;
//            service.Type = (ServiceType)model.ServiceTypeId;

//            if (model.ImageData != null && model.ImageData.Length > 0)
//            {
//                var filePath = Path.Combine("wwwroot/images", model.ImageName);
//                await File.WriteAllBytesAsync(filePath, model.ImageData);

//                service.Image = $"/images/{model.ImageName}";
//            }

//            await serviceCatalogRepository.UpdateAsync(service);
//            return true;
//        }


//        //public async Task<ServiceCatalogFormModel> GetServiceByIdAsync(Guid id)
//        //{
//        //    var service = await this.serviceCatalogRepository
//        //        .FirstOrDefaultAsync(s => s.Id == id);

//        //    if (service == null)
//        //    {
//        //        throw new InvalidOperationException("Service not found.");
//        //    }

//        //    return new ServiceCatalogFormModel
//        //    {
//        //        Name = service.Name,
//        //        Description = service.Description,
//        //        ServiceTypeId = service.ServiceTypeId,
//        //        ImageName = service.ImageName,
//        //        ImageData = service.ImageData
//        //    };
//        //}

//        /*public async Task<ServiceCatalog?> GetServiceByIdAsync(Guid id)
//        {
//            return await serviceCatalogRepository
//                .GetAllAttached()
//                .Where(s => s.Id == id && !s.IsDeleted)
//                .FirstOrDefaultAsync();
//        }*/


       


//        public IEnumerable<ServiceTypeViewModel> GetServiceTypes()
//        {
//            return Enum.GetValues<ServiceType>()
//                .Select(t => new ServiceTypeViewModel
//                {
//                    Id = (int)t,
//                    Name = t.ToString()
//                });
//        }

//       // private async Task<IEnumerable<ServiceTypeViewModel>> GetTypes()
//       //=> await serviceCatalogRepository.Ser
//       //        .AsNoTracking()
//       //           .Select(c => new ServiceTypeViewModel
//       //           {
//       //               Id = c.Id,
//       //               Name = c.Name,
//       //           })
//       //           .ToListAsync();


//    }
//}
