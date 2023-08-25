using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Skill
{
    public class SkillPutDto:IDto
    {

        public int SkillId { get; set; }
        public int UserId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public string? LevelName { get; set; }

        
    }
}
