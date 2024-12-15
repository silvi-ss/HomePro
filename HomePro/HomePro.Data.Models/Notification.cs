using HomePro.Data.Models.Enums;

namespace HomePro.Data.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string ClientId { get; set; } = null!;
        public bool IsRead { get; set; } = false;
        public NotificationType Type { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
