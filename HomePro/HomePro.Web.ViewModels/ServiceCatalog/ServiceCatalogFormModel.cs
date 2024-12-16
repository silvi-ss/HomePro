using System.ComponentModel.DataAnnotations;
using HomePro.Data.Models;
using HomePro.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomePro.Web.ViewModels.ServiceCatalog
{
    public class ServiceCatalogFormModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(
            EntityValidationConstants.ServiceCatalog.NameMaxLength,
            MinimumLength = EntityValidationConstants.ServiceCatalog.NameMinLength,
            ErrorMessage = "Name must be between {2} and {1} characters")]
        [Display(Name = "Service Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Description is required")]
        [StringLength(
            EntityValidationConstants.ServiceCatalog.DescriptionMaxLength,
            MinimumLength = EntityValidationConstants.ServiceCatalog.DescriptionMinLength,
            ErrorMessage = "Description must be between {2} and {1} characters")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Service type is required")]
        public int ServiceTypeId { get; set; }

        public ICollection<ServiceTypeViewModel> ServiceTypes { get; set; }
        = new List<ServiceTypeViewModel>();

        [Display(Name = "Image")]
        [StringLength(
            EntityValidationConstants.ServiceCatalog.ImageMaxLength,
            ErrorMessage = "Image URL cannot be longer than {1} characters")]
        public string? Image { get; set; }

        /*private async Task<ICollection<ServiceTypeViewModel>> GetServiceTypes()
       => await .Categories
               .AsNoTracking()
                  .Select(c => new ServiceTypeViewModel
                  {
                      Id = c.Id,
                      Name = c.Name,
                  })
                  .ToListAsync();*/

    }
}
