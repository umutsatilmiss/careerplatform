using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Application;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace CareerPlatform.Business.Implementations
{
    public class ApplicationBs : IApplicationBs
    {
        private readonly IApplicationRepository _repo;
        private readonly IMapper _mapper;

        public ApplicationBs(IApplicationRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0 dan büyük olmalıdır.");
            }
            var application = await _repo.GetByIdAsync(id);
            if(application != null)
            {
                await _repo.DeleteAsync(application);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen idye Göre uygun başvuru bulunamadı");

        }

        public async Task<ApiResponse<ApplicationGetDto>> GetApplicationByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0 dan büyük olmalıdır.");
            }
            var application = await _repo.GetByIdAsync(id, includeList);
            if (application != null)
            {
                var dto = _mapper.Map<ApplicationGetDto>(application);
                return ApiResponse<ApplicationGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamdı");
        }



        public async Task<ApiResponse<List<ApplicationGetDto>>> GetApplicationsAsync(params string[] includeList)
        {
            var application = await _repo.GetAllAsync(includeList: includeList);
            if (application != null && application.Count > 0) 
            {
                var returnList = _mapper.Map<List<ApplicationGetDto>>(application);
                var response = ApiResponse<List<ApplicationGetDto>>.Success
                    (StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("içerik bulunamadı");
        }

        public async Task<ApiResponse<List<ApplicationGetDto>>> GetApplicationsByStatusAsync(string statusti, params string[] includeList)
        {
            statusti = statusti.Trim();
            if (statusti.Length < 1)
            {
                throw new BadRequestException("En az 1 Karakter Girmelisiniz");
            }
            var applications = await _repo.GetByStatusAsync(statusti, includeList);
            if (applications != null && applications.Count > 0)
            {
                var returnList = _mapper.Map<List<ApplicationGetDto>>(applications);
                return ApiResponse<List<ApplicationGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("içerik bulunamadı");
        }

        public async Task<ApiResponse<Application>> InsertAsync(ApplicationPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek başvuru bilgileri bulunamadı");
            }
            if (dto.JobId <= 0)
            {
                throw new BadRequestException("İş Id değeri 0 dan büyük olmalıdır");
            }
            if (dto.UserId <= 0)
            {
                throw new BadRequestException("Kullanıcı ıd değeri 0 dan büyük olmalıdır.");
            }
            var application = _mapper.Map<Application>(dto);
            var insertApplication = await _repo.InsertAsync(application);
            return ApiResponse<Application>.Success(StatusCodes.Status201Created,
                insertApplication);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ApplicationPutDto dto)
        {

            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek başvuru bilgileri bulunamadı");
            }
            if (dto.JobId <= 0)
            {
                throw new BadRequestException("İş Id değeri 0 dan büyük olmalıdır");
            }
            if (dto.UserId <= 0)
            {
                throw new BadRequestException("Kullanıcı ıd değeri 0 dan büyük olmalıdır.");
            }

            var application = await _repo.GetByIdAsync(dto.ApplyId);
            if (application != null)
            {
                var applicationUpdated = _mapper.Map<Application>(dto);
                await _repo.UpdateAsync(applicationUpdated);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Güncellemek istediğiniz içerik bulunmadı");
        }
    }
}
