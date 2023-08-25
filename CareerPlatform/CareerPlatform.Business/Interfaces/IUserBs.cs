using CareerPlatform.Model.Dtos.User;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface IUserBs
    {
        Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetUserByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetUserByNameAsync(string name, params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetUserByEmailAsync(string email, params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetUserByPasswordAsync(string password, params string[] includeList);
        Task<ApiResponse<UserGetDto>> GetUserByAddressAsync(string address, params string[] includeList);


        Task<ApiResponse<User>> InsertAsync(UserPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(UserPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);


    }
}
