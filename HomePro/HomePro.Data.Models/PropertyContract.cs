
namespace HomePro.Data.Models
{
    public class PropertyContract
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ContractNumber { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal MonthlyFee { get; set; }

        public Guid PropertyId { get; set; }

        public Property Property { get; set; } = null!;

        public Guid ClientId { get; set; }

        public ApplicationUser Client { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
