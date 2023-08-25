using CareerPlatform.Model.Dtos.Message;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface IMessageBs
    {
        Task<ApiResponse<List<MessageGetDto>>> GetMessagesAsync(params string[] includeList);
        Task<ApiResponse<MessageGetDto>> GetMessageByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<MessageGetDto>>> GetMessageByTitleAsync(string title, params string[] includeList);

        Task<ApiResponse<List<MessageGetDto>>> GetMessagesContentAsync(string content, params string[] includeList);


        Task<ApiResponse<Message>> InsertAsync(MessagePostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
