using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Education;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace CareerPlatform.Business.Implementations
{
    public class EducationBs : IEducationBs
    {
        private readonly IEducationRepository _repo;
        private readonly IMapper _mapper;

        public EducationBs(IEducationRepository repo, IMapper mapper)
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
            var education = await _repo.GetByIdAsync(id);
            if (education != null)
            {
                await _repo.DeleteAsync(education);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girmiş olduğunuz Id'ye göre içerik bulunamadı.");
        }

        public async Task<ApiResponse<List<EducationGetDto>>> GetEducationByDepartmentAsync(string department, params string[] includeList)
        {
            department = department.Trim();
            if (department.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var departments = await _repo.GetByDepartmentAsync(department, includeList);
            if (departments != null && departments.Count > 0)
            {
                var returnList = _mapper.Map<List<EducationGetDto>>(departments);
                return ApiResponse<List<EducationGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<EducationGetDto>> GetEducationByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var education = await _repo.GetByIdAsync(id, includeList);
            if (education != null)
            {
                var dto = _mapper.Map<EducationGetDto>(education);
                return ApiResponse<EducationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<EducationGetDto>> GetEducationBySchoolAsync(string school, params string[] includeList)
        {
            school = school.Trim();
            if (school.Length < 1 || school == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var schools = await _repo.GetBySchoolAsync(school, includeList);
            if (schools != null)
            {
                var dto = _mapper.Map<EducationGetDto>(school);
                return ApiResponse<EducationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<EducationGetDto>>> GetEducationsAsync(params string[] includeList)
        {
            var educations = await _repo.GetAllAsync(includeList: includeList);
            if (educations != null && educations.Count > 0)
            {
                var returnList = _mapper.Map<List<EducationGetDto>>(educations);
                var response = ApiResponse<List<EducationGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<Education>> InsertAsync(EducationPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek Eğitim bilgileri bulunamadı.");
            }
            dto.School = dto.School.Trim();
            dto.Department = dto.Department.Trim();
            if (dto.School.Length < 2 || dto.Department.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek okul ismi ve depertman kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var education = _mapper.Map<Education>(dto);
            var insertedEducation = await _repo.InsertAsync(education);
            return ApiResponse<Education>.Success(StatusCodes.Status201Created, insertedEducation);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(EducationPutDto dto)
        {

            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek eğitim bilgisi bulunamadı.");
            }
            dto.School = dto.School.Trim();
            if (dto.School.Length == 5)
            {
                throw new BadRequestException("Okul Id 5 karakter olmalı.");
            }
            if (dto.Department.Length < 2)
            {
                throw new BadRequestException("Departmant ismi en az 2 karakter olmalıdır.");
            }
            if (dto.School.Length < 3)
            {
                throw new BadRequestException("Okul ismi en az 3 karakter olmalıdır.");
            }
            var educationDto = await _repo.GetByIdAsync(dto.EducationId);
            if (educationDto != null)
            {
                var education = _mapper.Map<Education>(dto);
                await _repo.UpdateAsync(education);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new BadRequestException("Girmiş olduğunuz Id'ye göre Kişi bulunamadı.");
        }
    }
}
