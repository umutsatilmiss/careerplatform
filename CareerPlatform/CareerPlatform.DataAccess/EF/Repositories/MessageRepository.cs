using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class MessageRepository : BaseRepository<Message, CareerPlatformContext>, IMessageRepository
    {
        public async Task<List<Message>> GetByCompanyAsync(int companyid, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.CompanyId == companyid, includeList);
        }

        public async Task<Message> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.MessagesId == id, includeList);
        }

        public async Task<List<Message>> GetByMessageContentAsync(string content, params string[] includeList)
        {
            return await GetAllAsync (prd => prd.MessageContent == content, includeList);
        }

        public async Task<List<Message>> GetByMessageTitleAsync(string title, params string[] includeList)
        {
           return await GetAllAsync(prd => prd.MessageTitle == title, includeList);
        }

        public async Task<List<Message>> GetByUserAsync(int userid, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.UserId == userid, includeList);
        }
    }
}
