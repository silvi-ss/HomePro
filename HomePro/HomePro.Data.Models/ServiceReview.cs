using HomePro.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePro.Data.Models
{
    public class ServiceReview
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; } = null!;

        public Guid ClientId { get; set; }
        public ApplicationUser Client { get; set; } = null!;

    }
}
