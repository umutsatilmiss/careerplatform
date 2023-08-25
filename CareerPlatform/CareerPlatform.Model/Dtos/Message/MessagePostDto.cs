using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Message
{
    public class MessagePostDto : IDto
    {

        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
