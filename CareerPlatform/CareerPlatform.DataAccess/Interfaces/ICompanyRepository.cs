using CareerPlatform.Model.Entities;
using Infrastructure.DataAccess.Interfaces;

namespace CareerPlatform.DataAccess.Interfaces
{
    public interface ICompanyRepository:IBaseRepository<Company>
    {
        Task<Company> GetByIdAsync(int id, params string[] includeList);
        Task<Company> GetByNameAsync(string companyName, params string[] includeList);
        Task<List<Company>> GetByDescriptionAsync(string companyDescription, params string[] includeList);
        Task<List<Company>> GetByAddressAsync(string CompanyAddress, params string[] includeList);
        Task<List<Company>> GetByWebsiteAsync(string CompanyAddress, params string[] includeList);



    }
}
