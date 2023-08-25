using CareerPlatform.Model.Dtos.Skill;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface ISkillBs
    {
        Task<ApiResponse<List<SkillGetDto>>> GetSkillAsync(params string[] includeList);
        Task<ApiResponse<SkillGetDto>> GetSkillByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<SkillGetDto>> GetSkillByNameAsync(string name, params string[] includeList);

        Task<ApiResponse<List<SkillGetDto>>> GetSkillByDescriptionAsync(string description, params string[] includeList);

        Task<ApiResponse<SkillGetDto>> GetSkillByLevelNameAsync(string name, params string[] includeList);

        Task<ApiResponse<Skill>> InsertAsync(SkillPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(SkillPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);


    }
}
