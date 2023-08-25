using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Job;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;

namespace CareerPlatform.Business.Implementations
{
    public class JobBs : IJobBs
    {
        private readonly IJobRepository _repo;
        private readonly IMapper _mapper;

        public JobBs(IJobRepository repo , IMapper mapper)
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
            var job = await _repo.GetByIdAsync(id);
            if (job != null)
            {
                await _repo.DeleteAsync(job);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id'ye göre uygun kategori bulunamadı.");
        }

        public async Task<ApiResponse<List<JobGetDto>>> GetJobByDescriptionAsync(string descriptio, params string[] includeList)
        {
            descriptio = descriptio.Trim();
            if (descriptio.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var jobs = await _repo.GetByDecriptionAsync(descriptio, includeList);
            if (jobs != null && jobs.Count > 0)
            {
                var returnList = _mapper.Map<List<JobGetDto>>(jobs);
                return ApiResponse<List<JobGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<JobGetDto>> GetJobByIdAsync(int id, params string[] includeList)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var job = await _repo.GetByIdAsync(id, includeList);
            if (job != null)
            {
                var dto = _mapper.Map<JobGetDto>(job);
                return ApiResponse<JobGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        

        public async Task<ApiResponse<JobGetDto>> GetJobByTitleAsync(string title, params string[] includeList)
        {
            title = title.Trim();
            if (title.Length < 1 || title == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var job = await _repo.GetByTitleAsync(title, includeList);
            if (job != null)
            {
                var dto = _mapper.Map<JobGetDto>(job);
                return ApiResponse<JobGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<JobGetDto>>> GetJobsAsync(params string[] includeList)
        {
            var jobs = await _repo.GetAllAsync(includeList: includeList);
            if (jobs != null && jobs.Count > 0)
            {
                var returnList = _mapper.Map<List<JobGetDto>>(jobs);
                var response = ApiResponse<List<JobGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik bulunamadı.");
        }

        public async Task<ApiResponse<Job>> InsertAsync(JobPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek iş bilgileri bulunamadı.");
            }
            dto.JobTitle = dto.JobTitle.Trim();
            dto.JobDecription = dto.JobDecription.Trim();
            if (dto.JobTitle.Length < 2 || dto.JobDecription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek iş ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var job = _mapper.Map<Job>(dto);
            var insertedJob = await _repo.InsertAsync(job);
            return ApiResponse<Job>.Success(StatusCodes.Status201Created, insertedJob);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(JobPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek iş bilgilerini yollamalısınız.");
            }
            if (dto.JobId <= 0)
            {
                throw new BadRequestException("JobId değeri 0'dan büyük olmalıdır.");
            }
            dto.JobTitle = dto.JobTitle.Trim();
            dto.JobDecription = dto.JobDecription.Trim();
            if (dto.JobTitle.Length < 2 || dto.JobDecription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek iş ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var Job = _mapper.Map<Job>(dto);
            await _repo.UpdateAsync(Job);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
