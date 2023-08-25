using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Notification;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace CareerPlatform.Business.Implementations
{
    public class NotificationBs : INotificationBs
    {
        private readonly INotificationRepository _repo;
        private readonly IMapper _mapper;

        public NotificationBs(INotificationRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var notification = await _repo.GetByIdAsync(id);
            if (notification != null)
            {
                await _repo.DeleteAsync(notification);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id'ye göre uygun kategori bulunamadı.");
        }

        public async Task<ApiResponse<NotificationGetDto>> GetByNotificationIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var notification = await _repo.GetByIdAsync(id, includeList);
            if (notification != null)
            {
                var dto = _mapper.Map<NotificationGetDto>(notification);
                return ApiResponse<NotificationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<NotificationGetDto>>> GetNotificationAsync(params string[] includeList)
        {
            var notifications = await _repo.GetAllAsync(includeList: includeList);
            if (notifications != null && notifications.Count > 0)
            {
                var returnList = _mapper.Map<List<NotificationGetDto>>(notifications);
                var response = ApiResponse<List<NotificationGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<NotificationGetDto>> GetNotificationByUserAsync(int userİd, params string[] includeList)
        {
            if (userİd <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var notification = await _repo.GetByIdAsync(userİd, includeList);
            if (notification != null)
            {
                var dto = _mapper.Map<NotificationGetDto>(notification);
                return ApiResponse<NotificationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<NotificationGetDto>>> GetNotificationsByContentAsync(string content, params string[] includeListn)
        {
            content = content.Trim();
            if (content.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var notifications = await _repo.GetByContentAsync(content, includeListn);
            if (notifications != null && notifications.Count > 0)
            {
                var returnList = _mapper.Map<List<NotificationGetDto>>(notifications);
                return ApiResponse<List<NotificationGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<Notification>> InsertAsync(NotificationPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
            }
            dto.NotificationContent = dto.NotificationContent.Trim();
           
            if (dto.NotificationContent.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek bildirim içeriği en az 2 karakter uzunluğunda olmalıdır.");
            }
            var Notification = _mapper.Map<Notification>(dto);
            var insertedNotification = await _repo.InsertAsync(Notification);
            return ApiResponse<Notification>.Success(StatusCodes.Status201Created, insertedNotification);
        }
    }
}
