using CareerPlatform.Model.Dtos.Job;
using CareerPlatform.Model.Dtos.Message;
using CareerPlatform.Model.Dtos.Notification;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Company
{
    public class CompanyGetDto:IDto
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyWebsite { get; set; }

        public List<MessageGetDto>? Message { get; set; }
        public List<NotificationGetDto>? Notification { get; set; }
        public List<JobGetDto>? Job { get; set; }
    }
}
