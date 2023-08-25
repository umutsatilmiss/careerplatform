using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;

namespace CareerPlatform.Business.Interfaces
{
    public interface INotificationBs
    {
        Task<ApiResponse<List<NotificationGetDto>>> GetNotificationAsync(params string[] includeList);
        Task<ApiResponse<NotificationGetDto>> GetByNotificationIdAsync(int id, params string[] includeList);

        Task<ApiResponse<NotificationGetDto>> GetNotificationByUserAsync(int userİd, params string[] includeList);

        Task<ApiResponse<List<NotificationGetDto>>> GetNotificationsByContentAsync(string content, params string[] includeListn);
        Task<ApiResponse<Notification>> InsertAsync(NotificationPostDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
