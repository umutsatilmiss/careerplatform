using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using System.Xml.Linq;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class NotificationRepositorty : BaseRepository<Notification, CareerPlatformContext>, INotificationRepository
    {
        public async Task<List<Notification>> GetByCompanyAsync(int companyId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Company.CompanyId == companyId, includeList);
        }

        public async Task<List<Notification>> GetByContentAsync(string content, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.NotificationContent.ToLower() == content.ToLower(), includeList);
        }

        public async Task<Notification> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.NotificationId == id, includeList);
        }

        public async Task<List<Notification>> GetByUserAsync(int userId, params string[] includeList)
        {
            return await GetAllAsync (prd => prd.UserId == userId, includeList);
        } 
    }
}
