using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface IEducationRepository:IBaseRepository<Education>
    {
        Task<Education> GetByIdAsync(int id, params string[] includeList);
        Task<Education> GetBySchoolAsync(string school, params string[] includeList);
        Task<List<Education>> GetByDepartmentAsync (string department, params string[] includeList);

        Task<List<Education>> GetByUserAsync (int userId, params string[] includeList);
    }
}
