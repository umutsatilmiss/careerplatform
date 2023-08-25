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
    public class EducationRepository : BaseRepository<Education, CareerPlatformContext>, IEducationRepository
    {
        public async Task<List<Education>> GetByDepartmentAsync(string department, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Department.ToLower() == department.ToLower(), includeList);
        }

        public async Task<Education> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.EducationId == id, includeList);
        }

        public async Task<Education> GetBySchoolAsync(string school, params string[] includeList)
        {
            return await GetAsync(prd => prd.School.ToLower() == school.ToLower(), includeList);
        }

        public async Task<List<Education>> GetByUserAsync(int userId, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.UserId == userId, includeList);
        }
    }
}
