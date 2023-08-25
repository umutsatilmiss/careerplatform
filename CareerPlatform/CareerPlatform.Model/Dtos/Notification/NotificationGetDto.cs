using CareerPlatform.Model.Dtos.User;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Notification
{
    public class NotificationGetDto:IDto
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string? NotificationContent { get; set; }
        public int CompanyId { get; set; }
        public DateTime? NotificationDate { get; set; }

        public UserGetDto? User { get; set; }
        public UserGetDto? Company { get; set; }
    }
}
