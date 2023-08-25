using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class ApplicationRepository : BaseRepository<Application, CareerPlatformContext>, IApplicationRepository
    {
        public async Task<Application> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.ApplyId == id, includeList);
        }

        public async Task<List<Application>> GetByStatusAsync(string status, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Status.Contains(status), includeList);
        }
    }
}
