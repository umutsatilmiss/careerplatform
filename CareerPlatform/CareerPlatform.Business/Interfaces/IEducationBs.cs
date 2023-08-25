using CareerPlatform.Model.Dtos.Education;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface IEducationBs
    {
        Task<ApiResponse<List<EducationGetDto>>> GetEducationsAsync(params string[] includeList);
        Task<ApiResponse<EducationGetDto>> GetEducationByIdAsync(int id, params string[] includeList);

        Task<ApiResponse<EducationGetDto>> GetEducationBySchoolAsync(string school, params string[] includeList);

        Task<ApiResponse<List<EducationGetDto>>> GetEducationByDepartmentAsync(string department, params string[] includeList);

        Task<ApiResponse<Education>> InsertAsync(EducationPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(EducationPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
