namespace HomePro.Services.Data.Interfaces
{

    using HomePro.Web.ViewModels.ServiceCatalog;

    public interface IServiceCatalogService
    {
        Task<IEnumerable<ServiceCatalogIndexViewModel>> GetAllServicesAsync();

		Task<bool> AddServiceAsync(ServiceCatalogFormModel model);

	}
}
