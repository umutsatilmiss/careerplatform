using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Skill:IEntity
    {
        public int SkillId { get; set; }
        public int? UserId { get; set; }
        public string? SkillName { get; set; }
        public string? SkillDescription { get; set; }
        public string? LevelName { get; set; }

        public User? User { get; set; }

    }
}
