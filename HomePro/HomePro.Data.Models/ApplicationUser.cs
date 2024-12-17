using Microsoft.AspNetCore.Identity;

namespace HomePro.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
            = new HashSet<Property>();
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
        public virtual ICollection<ServiceReview> Reviews { get; set; }
            = new HashSet<ServiceReview>();
        public virtual ICollection<UserFavoriteService> FavoriteServices { get; set; }
             = new HashSet<UserFavoriteService>();

    }
}
