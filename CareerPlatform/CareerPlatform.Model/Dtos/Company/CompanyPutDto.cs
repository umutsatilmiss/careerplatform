using Infrastructure.Model;

namespace CareerPlatform.Model.Dtos.Company
{
    public class CompanyPutDto:IDto
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Industry { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }
        public string? CompanyWebsite { get; set; }
    }
}
