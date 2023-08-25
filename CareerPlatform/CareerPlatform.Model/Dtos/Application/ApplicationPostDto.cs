using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Application
{
    public class ApplicationPostDto:IDto
    {
        public int JobId { get; set; }
        public int UserId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? Status { get; set; }
        public int CompanyId { get; set; }
    }
}
