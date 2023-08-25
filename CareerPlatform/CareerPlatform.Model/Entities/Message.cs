using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Message:IEntity
    {
        public int MessagesId { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public string? MessageTitle { get; set; }
        public string? MessageContent { get; set; }
        public DateTime? MessageDate { get; set; }

        public Company? Company { get; set; }
        public User? User { get; set; }
    }
}
