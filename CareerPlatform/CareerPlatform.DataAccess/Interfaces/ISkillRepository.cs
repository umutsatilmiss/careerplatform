using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface ISkillRepository:IBaseRepository<Skill>
    {
        Task<Skill> GetByIdAsync(int id, params string[] includeList);
        Task<Skill> GetByNameAsync(string name, params string[] includeList);
        Task<List<Skill>> GetByDescriptionAsync(string description, params string[] includeList);

        Task<Skill> GetByLevelNameAsync(string name, params string[] includeList);
    }
}
