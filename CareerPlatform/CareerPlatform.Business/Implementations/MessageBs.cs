using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Message;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace CareerPlatform.Business.Implementations
{
    public class MessageBs : IMessageBs
    {
        private readonly IMessageRepository _repo;
        private readonly IMapper _mapper;

        public MessageBs(IMessageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var message = await _repo.GetByIdAsync(id);
            if (message != null)
            {
                await _repo.DeleteAsync(message);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girmiş olduğunuz Id'ye göre içerik bulunamadı.");
        }

        public async Task<ApiResponse<MessageGetDto>> GetMessageByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var message = await _repo.GetByIdAsync(id, includeList);
            if (message != null)
            {
                var dto = _mapper.Map<MessageGetDto>(message);
                return ApiResponse<MessageGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<MessageGetDto>>> GetMessageByTitleAsync(string title, params string[] includeList)
        {
            title = title.Trim();
            if (title.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var messages = await _repo.GetByMessageTitleAsync(title, includeList);
            if (messages != null && messages.Count > 0)
            {
                var returnList = _mapper.Map<List<MessageGetDto>>(messages);
                return ApiResponse<List<MessageGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<MessageGetDto>>> GetMessagesAsync(params string[] includeList)
        {
            var messages = await _repo.GetAllAsync(includeList: includeList);
            if (messages != null && messages.Count > 0)
            {
                var returnList = _mapper.Map<List<MessageGetDto>>(messages);
                var response = ApiResponse<List<MessageGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<MessageGetDto>>> GetMessagesContentAsync(string content, params string[] includeList)
        {
            content = content.Trim();
            if (content.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var messages = await _repo.GetByMessageContentAsync(content, includeList);
            if (messages != null && messages.Count > 0)
            {
                var returnList = _mapper.Map<List<MessageGetDto>>(messages);
                return ApiResponse<List<MessageGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<Message>> InsertAsync(MessagePostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
            }
            dto.MessageTitle = dto.MessageTitle.Trim();
            dto.MessageContent = dto.MessageContent.Trim();
            if (dto.MessageTitle.Length < 2 || dto.MessageContent.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek mesaj başlığı ve içerik kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var message = _mapper.Map<Message>(dto);
            var insertedMessage = await _repo.InsertAsync(message);
            return ApiResponse<Message>.Success(StatusCodes.Status201Created, insertedMessage);
        }
    }
}
