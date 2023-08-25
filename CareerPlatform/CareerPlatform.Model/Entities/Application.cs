using Infrastructure.Model;

namespace CareerPlatform.Model.Entities
{
    public class Application :IEntity
    {
        public int ApplyId { get; set; }
        public int? JobId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ApplyDate { get; set; }
        public string? Status { get; set; }
        public int? CompanyId { get; set; }

        public Company? Company { get; set; }
        public Job? Job { get; set; }
        public User? User { get; set; }
    }
}
