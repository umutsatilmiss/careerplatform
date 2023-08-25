using CareerPlatform.Business.Interfaces;
using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerPlatform.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        private readonly INotificationBs _notificationBs;

        public NotificationController(INotificationBs notificationBs)
        {
            _notificationBs = notificationBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<NotificationGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _notificationBs.GetByNotificationIdAsync(id, "Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<NotificationGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var response = await _notificationBs.GetNotificationAsync("Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ApplicationGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUser([FromRoute] int id)
        {
            var response = await _notificationBs.GetNotificationByUserAsync(id, "Products");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ApplicationGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("getByContent")]
        public async Task<IActionResult> GetByDescription([FromQuery] string content)
        {
            var response = await _notificationBs.GetNotificationsByContentAsync(content, "Users");
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Notification>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpPost]
        public async Task<IActionResult> SaveNewNotification([FromBody] NotificationPostDto dto)
        {
            var response = await _notificationBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return SendResponse(response);
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = response.Data.NotificationId }, response.Data);
            }
        }


        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifications([FromRoute] int id)
        {
            var response = await _notificationBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
