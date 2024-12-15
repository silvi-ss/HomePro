
namespace HomePro.Data.Models
{
    public class Address
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? District { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string StreetNumber { get; set; } = null!;
        public string? BuildingNumber { get; set; }
        public string? Floor { get; set; } = null!;
        public string? Entry { get; set; }
        public string PostalCode { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
    }
}
