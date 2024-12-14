using HomePro.Data.Models.Enums;

namespace HomePro.Data.Models
{
    public class ServiceCatalog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ServiceType Type { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();

    }
}
