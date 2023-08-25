using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Company : IEntity
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyWebsite { get; set; }

        public List<Message>? Message { get; set; }
        public List<Notification>? Notification { get; set; }
        public List<Job>? Job { get; set; }


    }
}
