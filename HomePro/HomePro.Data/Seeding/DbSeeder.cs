
using HomePro.Data.Seeding.DataTranferObjects;
using HomePro.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
//using static HomePro.Common.EntityValidationConstants;


using System.Globalization;


using Microsoft.EntityFrameworkCore;


namespace HomePro.Data.Seeding
{
    public static class DbSeeder
    {
        public static async Task SeedServicesAsync(IServiceProvider services, string jsonPath)
        {
            using var dbContext = services.GetRequiredService<ApplicationDbContext>();
                       
            ICollection<ServiceCatalog> existingServices = await dbContext
                .ServiceCatalogs
                .ToListAsync();

            try
            {
                string jsonInput = await File.ReadAllTextAsync(jsonPath, Encoding.UTF8);

                ImportServiceDto[] serviceDtos =
                    JsonConvert.DeserializeObject<ImportServiceDto[]>(jsonInput);

                foreach (ImportServiceDto serviceDto in serviceDtos)
                {
                    if (!IsValid(serviceDto))
                    {
                        continue;
                    }

                    if (!Guid.TryParse(serviceDto.Id, out Guid serviceId))
                    {
                        continue;
                    }

                    if (existingServices.Any(s => s.Id == serviceId))
                    {
                        continue;
                    }

                    ServiceCatalog service = new ServiceCatalog
                    {
                        Id = serviceId,
                        Name = serviceDto.Name,
                        Description = serviceDto.Description,
                        Image = serviceDto.Image,
                        IsDeleted = false
                    };

                    await dbContext.ServiceCatalogs.AddAsync(service);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occurred while seeding services: {e.Message}");
            }
        }

        private static bool IsValid(object obj)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(obj);

            return Validator.TryValidateObject(obj, context, validationResults, true);
        }
    }
}
