using CareerPlatform.DataAccess.EF.Contexts;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Implementations.EF;

namespace CareerPlatform.DataAccess.EF.Repositories
{
    public class CompanyRepository : BaseRepository<Company, CareerPlatformContext>, ICompanyRepository
    {
        public async Task<List<Company>> GetByAddressAsync(string CompanyAddress, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.CompanyAddress.ToLower() == CompanyAddress.ToLower());
        }

        public async Task<List<Company>> GetByDescriptionAsync(string companyDescription, params string[] includeList)
        {
           return await GetAllAsync(prd => prd.CompanyDescription ==  companyDescription);
        }

        public async Task<Company> GetByNameAsync(string companyName, params string[] includeList)
        {
            return await GetAsync(prd => prd.CompanyName.ToLower() == companyName.ToLower());
        }
        public async Task<List<Company>> GetByWebsiteAsync(string CompanyAddress, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.CompanyWebsite ==  CompanyAddress.ToLower());
        }

        public async Task<Company> GetByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.CompanyId == id);
        }
    }
}
