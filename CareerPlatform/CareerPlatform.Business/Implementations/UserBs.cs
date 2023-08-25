using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.User;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace CareerPlatform.Business.Implementations
{
    public class UserBs : IUserBs
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserBs(IUserRepository repo, IMapper mapper)
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
            var user = await _repo.GetByIdAsync(id);
            if (user != null)
            {
                await _repo.DeleteAsync(user);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id'ye göre uygun kategori bulunamadı.");
        }

        public async Task<ApiResponse<UserGetDto>> GetUserByAddressAsync(string address, params string[] includeList)
        {
            address = address.Trim();
            if (address.Length < 1 || address == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var user = await _repo.GetByNameAsync(address, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public Task<ApiResponse<UserGetDto>> GetUserByEmailAsync(string email, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<UserGetDto>> GetUserByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var user = await _repo.GetByIdAsync(id, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<UserGetDto>> GetUserByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var user = await _repo.GetByNameAsync(name, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<UserGetDto>> GetUserByPasswordAsync(string password, params string[] includeList)
        {
            password = password.Trim();
            if (password.Length < 1 || password == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var user = await _repo.GetByNameAsync(password, includeList);
            if (user != null)
            {
                var dto = _mapper.Map<UserGetDto>(user);
                return ApiResponse<UserGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<UserGetDto>>> GetUsersAsync(params string[] includeList)
        {
            var users = await _repo.GetAllAsync(includeList: includeList);
            if (users != null && users.Count > 0)
            {
                var returnList = _mapper.Map<List<UserGetDto>>(users);
                var response = ApiResponse<List<UserGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<User>> InsertAsync(UserPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
            }
            dto.UserName = dto.UserName.Trim();
            dto.LastName = dto.LastName.Trim();
            if (dto.UserName.Length < 2 || dto.LastName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek kullanıcı ismi ve soyadı kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var user = _mapper.Map<User>(dto);
            var insertedCategory = await _repo.InsertAsync(user);
            return ApiResponse<User>.Success(StatusCodes.Status201Created, insertedCategory);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(UserPutDto dto)
        {

            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgilerini yollamalısınız.");
            }
            if (dto.UserId <= 0)
            {
                throw new BadRequestException("CategoryId değeri 0'dan büyük olmalıdır.");
            }
            dto.UserName = dto.UserName.Trim();
            dto.LastName = dto.LastName.Trim();
            if (dto.UserName.Length < 2 || dto.LastName.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var user = _mapper.Map<User>(dto);
            await _repo.UpdateAsync(user);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
