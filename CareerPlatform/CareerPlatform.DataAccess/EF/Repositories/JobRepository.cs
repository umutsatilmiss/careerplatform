using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using System.Xml.Linq;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class JobRepository : BaseRepository<Job, CareerPlatformContext>, IJobRepository
    {
        public async Task<List<Job>> GetByDecriptionAsync(string decription, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.JobDecription.Contains(decription), includeList);
        }

        public async Task<Job> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.JobId == id, includeList);
        }

        public async Task<List<Job>> GetByTitleAsync(string title, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.JobTitle.ToLower() == title.ToLower(), includeList);
        }
    }
}
