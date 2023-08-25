using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface IApplicationRepository:IBaseRepository<Application>
    {
        Task<Application> GetByIdAsync(int id, params string[] includeList);
        Task<List<Application>> GetByStatusAsync(string status, params string[] includeList);
    }
}
