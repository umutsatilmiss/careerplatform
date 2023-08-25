using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Dtos.User;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Message
{
    public class MessageGetDto:IDto
    {
        public int MessagesId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }

        public CompanyGetDto? Company { get; set; }
        public UserGetDto? User { get; set; }
    }
}
