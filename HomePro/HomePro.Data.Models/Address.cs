
namespace HomePro.Data.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public string StreetNumber { get; set; } = string.Empty;
        public string? BuildingNumber { get; set; }
        public string? Floor { get; set; } = string.Empty;
        public string? Entry { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
