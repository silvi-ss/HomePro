namespace HomePro.Data.Models
{
    using HomePro.Data.Models.Enums;
    using System.Diagnostics.Contracts;
    using System.Net;

    public class Property
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DisplayName { get; set; } = null!;
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public double SquareMeters { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public PropertyType Type { get; set; }
        public string OwnerId { get; set; } = null!;
        public ApplicationUser Owner { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? Image { get; set; }
        public virtual ICollection<PropertyContract> PropertyContracts { get; set; }
            = new HashSet<PropertyContract>();
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
    }
}
