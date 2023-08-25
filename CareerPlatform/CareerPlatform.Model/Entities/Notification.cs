using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Notification:IEntity
    {
        public int NotificationId { get; set; }
        public int? UserId { get; set; }
        public string? NotificationContent { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? NotificationDate { get; set; }

        public User? User { get; set; }
        public Company? Company { get; set; }
    }
}
