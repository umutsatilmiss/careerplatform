using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface INotificationRepository:IBaseRepository<Notification>
    {
        Task<Notification> GetByIdAsync(int id, params string[] includeList);
        Task<List<Notification>> GetByUserAsync(int userId, params string[] includeList);
        Task<List<Notification>> GetByContentAsync(string content, params string[] includeList);
        Task<List<Notification>> GetByCompanyAsync(int companyId, params string[] includeList);

     
    }
}
