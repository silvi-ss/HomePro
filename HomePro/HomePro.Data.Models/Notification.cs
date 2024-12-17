using HomePro.Data.Models.Enums;

namespace HomePro.Data.Models
{
    public class Notification : BaseEntity
    {
        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public Guid ClientId { get; set; } 
        public virtual ApplicationUser Client { get; set; } = null!;

        public Guid? ServiceRequestId { get; set; }  
        public virtual ServiceRequest? ServiceRequest { get; set; }

        public NotificationType Type { get; set; } 

        public bool IsRead { get; set; } = false;   
    }
}
