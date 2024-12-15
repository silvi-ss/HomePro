using HomePro.Data.Models.Enums;

namespace HomePro.Data.Models
{
    public class ServiceRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public Guid ClientId { get; set; }
        public ApplicationUser Client { get; set; } = null!;
        public Guid ServiceCatalogId { get; set; }
        public ServiceCatalog ServiceCatalog { get; set; } = null!;
        public ServiceFrequency Frequency { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
        public string? Description { get; set; }
        public DateTime PreferredDate { get; set; }
        public decimal FinalPrice { get; set; }
        public ServiceRequestStatus Status { get; set; } 
            = ServiceRequestStatus.Pending;
        public ICollection<ServiceReview> Reviews { get; set; }
            = new HashSet<ServiceReview>();
    }
}
