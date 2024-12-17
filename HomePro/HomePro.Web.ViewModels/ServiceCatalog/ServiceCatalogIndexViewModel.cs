namespace HomePro.Web.ViewModels.ServiceCatalog
{
    public class ServiceCatalogIndexViewModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Image { get; set; }
    }
}
