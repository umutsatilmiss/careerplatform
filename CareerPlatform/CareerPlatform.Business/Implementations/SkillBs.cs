using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Skill;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace CareerPlatform.Business.Implementations
{
    public class SkillBs : ISkillBs
    {
        private readonly ISkillRepository _repo;
        private readonly IMapper _mapper;

        public SkillBs(ISkillRepository repo, IMapper mapper)
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
            var skill = await _repo.GetByIdAsync(id);
            if (skill != null)
            {
                await _repo.DeleteAsync(skill);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id'ye göre uygun kategori bulunamadı.");
        }

        public async Task<ApiResponse<List<SkillGetDto>>> GetSkillAsync(params string[] includeList)
        {
            var skills = await _repo.GetAllAsync(includeList: includeList);
            if (skills != null && skills.Count > 0)
            {
                var returnList = _mapper.Map<List<SkillGetDto>>(skills);
                var response = ApiResponse<List<SkillGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<List<SkillGetDto>>> GetSkillByDescriptionAsync(string description, params string[] includeList)
        {
            description = description.Trim();
            if (description.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var skills = await _repo.GetByDescriptionAsync(description, includeList);
            if (skills != null && skills.Count > 0)
            {
                var returnList = _mapper.Map<List<SkillGetDto>>(skills);
                return ApiResponse<List<SkillGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<SkillGetDto>> GetSkillByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var skill = await _repo.GetByIdAsync(id, includeList);
            if (skill != null)
            {
                var dto = _mapper.Map<SkillGetDto>(skill);
                return ApiResponse<SkillGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<SkillGetDto>> GetSkillByLevelNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var skill = await _repo.GetByNameAsync(name, includeList);
            if (skill != null)
            {
                var dto = _mapper.Map<SkillGetDto>(skill);
                return ApiResponse<SkillGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<SkillGetDto>> GetSkillByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var skill = await _repo.GetByNameAsync(name, includeList);
            if (skill != null)
            {
                var dto = _mapper.Map<SkillGetDto>(skill);
                return ApiResponse<SkillGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<Skill>> InsertAsync(SkillPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgileri bulunamadı.");
            }
            dto.SkillName = dto.SkillName.Trim();
            dto.SkillDescription = dto.SkillDescription.Trim();
            if (dto.SkillName.Length < 2 || dto.SkillDescription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek kategori ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var skill = _mapper.Map<Skill>(dto);
            var insertedSkill = await _repo.InsertAsync(skill);
            return ApiResponse<Skill>.Success(StatusCodes.Status201Created, insertedSkill);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(SkillPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek kategori bilgilerini yollamalısınız.");
            }
            if (dto.SkillId <= 0)
            {
                throw new BadRequestException("CategoryId değeri 0'dan büyük olmalıdır.");
            }
            dto.SkillName = dto.SkillName.Trim();
            dto.SkillDescription = dto.SkillDescription.Trim();
            if (dto.SkillName.Length < 2 || dto.SkillDescription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek yetenek ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var skill = _mapper.Map<Skill>(dto);
            await _repo.UpdateAsync(skill);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
