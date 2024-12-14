using HomePro.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ServiceRequestStatus Status { get; set; } = ServiceRequestStatus.Pending;

    }
}
