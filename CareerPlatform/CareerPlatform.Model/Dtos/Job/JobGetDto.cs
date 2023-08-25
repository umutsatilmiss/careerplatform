using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Dtos.Company;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Job
{
    public class JobGetDto:IDto
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDecription { get; set; }
        public string? JobRequirements { get; set; }
        public string? JobLocation { get; set; }
        public string? JobType { get; set; }
        public decimal? Salary { get; set; }

        public CompanyGetDto? Company { get; set; }
        public List<ApplicationGetDto>? Application { get; set; }
    }
}
