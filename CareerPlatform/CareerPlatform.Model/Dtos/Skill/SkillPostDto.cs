using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Skill
{
    public class SkillPostDto:IDto
    {
        
        public int UserId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public string? LevelName { get; set; }

    }
}
