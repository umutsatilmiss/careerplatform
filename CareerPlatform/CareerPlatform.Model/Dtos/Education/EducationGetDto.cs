using CareerPlatform.Model.Dtos.User;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Education
{
    public class EducationGetDto:IDto
    {
        public int EducationId { get; set; }
        public int UserId { get; set; }
        public string? School { get; set; }
        public string? Department { get; set; }
        public DateTime StartingDate { get; set; }
        public bool Graduation { get; set; }
        public DateTime EndDate { get; set; }

        public UserGetDto? User { get; set; }
    }
}
