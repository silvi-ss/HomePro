using HomePro.Data.Models.Enums;

namespace HomePro.Data.Models
{
    public class ServiceCatalog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Image { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
        public ICollection<UserFavoriteService> UserFavorites { get; set; }
            = new HashSet<UserFavoriteService>();
    }
}
