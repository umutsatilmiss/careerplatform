using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface IUserRepository:IBaseRepository<User>
    {
        Task<User> GetByIdAsync(int id, params string[] includeList);
        Task<User> GetByNameAsync(string name, params string[] includeList);
        Task<User> GetByEmailAsync(string email, params string[] includeList);
        Task<User> GetByPasswordAsync(string password, params string[] includeList);
        Task<List<User>> GetByGenderAsync(string gender, params string[] includeList);
        Task<List<User>> GetByAddressAsync(string Address, params string[] includeList);
        Task<List<User>> GetByCvAsync(string cv, params string[] includeList);
    }
}
