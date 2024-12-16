namespace HomePro.Services.Data.Interfaces
{

    using HomePro.Web.ViewModels.ServiceCatalog;

    public interface IServiceCatalogService
    {
        IEnumerable<ServiceTypeViewModel> GetServiceTypes();

        Task<IEnumerable<ServiceCatalogIndexViewModel>> GetAllServicesAsync();

		Task<bool> AddServiceAsync(ServiceCatalogFormModel model);

	}
}
