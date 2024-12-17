using HomePro.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePro.Data.Models
{
    public class ServiceReview : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Comment { get; set; } = string.Empty;
        public Rating Rating { get; set; }
        public Guid ServiceRequestId { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; } = null!;
        public Guid ClientId { get; set; }
        public virtual ApplicationUser Client { get; set; } = null!;

    }
}
