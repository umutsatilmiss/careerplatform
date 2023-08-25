using CareerPlatform.Model.Dtos.Job;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface IJobBs
    {
        Task<ApiResponse<List<JobGetDto>>> GetJobsAsync(params string[] includeList);
        Task<ApiResponse<JobGetDto>> GetJobByIdAsync(int id, params string[] includeList);

        Task<ApiResponse<JobGetDto>> GetJobByTitleAsync(string title, params string[] includeList);
        Task<ApiResponse<List<JobGetDto>>> GetJobByDescriptionAsync(string descriptio, params string[] includeList);
        Task<ApiResponse<Job>> InsertAsync(JobPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(JobPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
