using System.ComponentModel.DataAnnotations;
using HomePro.Common;

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

        public IEnumerable<ServiceTypeViewModel> ServiceTypes { get; set; }
        = new List<ServiceTypeViewModel>();

        [Display(Name = "Image")]
        [StringLength(
            EntityValidationConstants.ServiceCatalog.ImageMaxLength,
            ErrorMessage = "Image URL cannot be longer than {1} characters")]
        public string? ImageName { get; set; }

        public byte[]? ImageData { get; set; }
    }
}
