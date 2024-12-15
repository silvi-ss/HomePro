using Microsoft.AspNetCore.Identity;

namespace HomePro.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public ICollection<Property> Properties { get; set; }
            = new HashSet<Property>();
        public ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
        public ICollection<ServiceReview> Reviews { get; set; }
            = new HashSet<ServiceReview>();
        public ICollection<UserFavoriteService> FavoriteServices { get; set; }
             = new HashSet<UserFavoriteService>();

    }
}
