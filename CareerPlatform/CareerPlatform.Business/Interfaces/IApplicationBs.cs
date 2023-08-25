using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface IApplicationBs
    {
        Task<ApiResponse<List<ApplicationGetDto>>> GetApplicationsAsync(params string[] includeList);
        Task<ApiResponse<ApplicationGetDto>> GetApplicationByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<ApplicationGetDto>>> GetApplicationsByStatusAsync(string statusti, params string[] includeList);

        Task<ApiResponse<Application>> InsertAsync(ApplicationPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(ApplicationPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
