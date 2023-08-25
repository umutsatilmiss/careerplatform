using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface IJobRepository:IBaseRepository<Job>
    {
        Task<Job> GetByIdAsync(int id, params string[] includeList);
        Task<List<Job>> GetByTitleAsync(string title, params string[] includeList);
        Task<List<Job>> GetByDecriptionAsync(string decription, params string[] includeList);

    }
}
