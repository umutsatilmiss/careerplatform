using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Dtos.Job;
using CareerPlatform.Model.Dtos.User;
using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Application
{
    public class ApplicationGetDto:IDto
    {
        public int ApplyId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? Status { get; set; }
        public JobGetDto Job { get; set; }
        public UserGetDto User { get; set; }
        public CompanyGetDto Company { get; set; }

    }
}
