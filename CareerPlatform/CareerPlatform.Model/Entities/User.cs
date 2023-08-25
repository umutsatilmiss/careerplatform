using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? CV { get; set; }

        public List<Skill>? Skills { get; set; }
        public List<Message>? Message { get; set; }

        public List<Education>? Educations { get; set; }
        public List<Application>? Application { get; set; }
        public List<Notification>? Notification { get; set; }


    }
}
