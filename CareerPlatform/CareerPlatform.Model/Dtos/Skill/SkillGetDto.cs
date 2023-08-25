using CareerPlatform.Model.Dtos.User;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Skill
{
    public class SkillGetDto:IDto
    {
        public int SkillId { get; set; }
        public int UserId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public string? LevelName { get; set; }

        public UserGetDto? User { get; set; }
    }
}
