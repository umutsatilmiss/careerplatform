using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Notification
{
    public class NotificationPostDto : IDto
    {

        public int UserId { get; set; }
        public string? NotificationContent { get; set; }
        public int CompanyId { get; set; }
        public DateTime? NotificationDate { get; set; }


    }
}
