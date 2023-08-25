using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Application
{
    public class ApplicationPutDto:IDto
    {
        public int ApplyId { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string? Status { get; set; }
        public int CompanyId { get; set; }
    }
}
