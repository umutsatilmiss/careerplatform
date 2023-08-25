using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Education:IEntity
    {
        public int EducationId { get; set; }
        public int? UserId { get; set; }
        public string? School { get; set; }
        public string? Department { get; set; }
        public DateTime? StartingDate { get; set; }
        public bool? Graduation { get; set; }
        public DateTime? EndDate { get; set; }

        public User? User { get; set; }
    }
}
