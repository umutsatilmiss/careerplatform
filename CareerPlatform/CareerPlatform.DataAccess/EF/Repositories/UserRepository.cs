using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;
using System.Xml.Linq;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class UserRepository : BaseRepository<User, CareerPlatformContext>, IUserRepository
    {
        public async Task<List<User>> GetByAddressAsync(string Address, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Address.Contains(Address), includeList);
        }

        public async Task<List<User>> GetByCvAsync(string cv, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.CV.Contains(cv), includeList);
        }

        public async Task<User> GetByEmailAsync(string email, params string[] includeList)
        {
            return await GetAsync(prd => prd.Email.Contains(email), includeList);
        }

        public async Task<List<User>> GetByGenderAsync(string gender, params string[] includeList)
        {
            return await GetAllAsync (prd => prd.Gender.ToLower() == gender.ToLower(), includeList);
        }

        public async Task<User> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.UserId == id, includeList);
        }

        public async Task<User> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAsync(prd => prd.UserName.ToLower() == name.ToLower(), includeList);
        }

        public async Task<User> GetByPasswordAsync(string password, params string[] includeList)
        {
            return await GetAsync(prd => prd.Password.ToLower() == password.ToLower(), includeList);
        }
    }
}
