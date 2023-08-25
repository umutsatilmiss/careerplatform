using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Dtos.Education;
using CareerPlatform.Model.Dtos.Message;
using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Dtos.Skill;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.User
{
    public class UserGetDto:IDto
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public string? CV { get; set; }

        public List<SkillGetDto>? Skills { get; set; }
        public List<MessageGetDto>? Message { get; set; }

        public List<EducationGetDto>? Educations { get; set; }
        public List<ApplicationGetDto>? Application { get; set; }
        public List<NotificationGetDto>? Notification { get; set; }
    }
}
