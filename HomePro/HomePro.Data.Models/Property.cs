namespace HomePro.Data.Models
{
    using HomePro.Data.Models.Enums;

    public class Property : BaseEntity
    {
        public string DisplayName { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; } = null!;
        public double SquareMeters { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; } = string.Empty;
        public PropertyType Type { get; set; }
        public Guid ClientId { get; set; }
        public virtual ApplicationUser Client { get; set; } = null!;
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
            = new HashSet<ServiceRequest>();
    }
}
