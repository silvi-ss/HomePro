﻿namespace HomePro.Data.Models
{
    using HomePro.Data.Models.Enums;

    public class Property
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DisplayName { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public double SquareMeters { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public PropertyType Type { get; set; }
        public Guid ClientId { get; set; }
        public ApplicationUser Client { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public string? Image { get; set; }
        
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
    }
}
