using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface IMessageRepository:IBaseRepository<Message>
    {
        Task<Message> GetByIdAsync(int id, params string[] includeList);

        Task<List<Message>> GetByMessageTitleAsync(string title, params string[] includeList);
        Task<List<Message>> GetByMessageContentAsync(string content, params string[] includeList);

        Task<List<Message>> GetByCompanyAsync(int companyid, params string[] includeList);
        Task<List<Message>> GetByUserAsync(int userid, params string[] includeList);

    }
}
