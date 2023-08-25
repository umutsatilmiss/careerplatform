using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class SkillRepository : BaseRepository<Skill, CareerPlatformContext>, ISkillRepository
    {
        public async Task<List<Skill>> GetByDescriptionAsync(string description, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.SkillDescription.Contains(description), includeList);
        }

        public async Task<Skill> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.SkillId == id, includeList);
        }

        public async Task<Skill> GetByLevelNameAsync(string name, params string[] includeList)
        {
            return await GetAsync(prd => prd.LevelName.ToLower() == name.ToLower(), includeList);
        }

        public async Task<Skill> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAsync(prd => prd.SkillName.ToLower() == name.ToLower(), includeList);
        }
    }
}
