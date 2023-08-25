using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface ICompanyBs
    {
        Task<ApiResponse<List<CompanyGetDto>>> GetCompanyAsync(params string[] includeList);
        Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByAdressAsync(string adress, params string[] includeList);
        Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByDescriptionAsync(string description , params string[] includeList);
        Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByWebsiteAsync(string website , params string[] includeList);
        Task<ApiResponse<CompanyGetDto>> GetCompanyByIdAsync(int id , params string[] includeList);
        Task<ApiResponse<CompanyGetDto>> GetByCompanyByNameAsync(string name,  params string[] includeList);
        Task<ApiResponse<Company>> InsertAsync(CompanyPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CompanyPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
