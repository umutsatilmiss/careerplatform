using AutoMapper;
using CareerPlatform.Business.CustomExceptions;
using CareerPlatform.Business.Interfaces;
using CareerPlatform.DataAccess.Interfaces;
using CareerPlatform.Model.Dtos.Company;
using CareerPlatform.Model.Entities;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;

namespace CareerPlatform.Business.Implementations
{
    public class CompanyBs : ICompanyBs
    {
        private readonly ICompanyRepository _repo;
        private readonly IMapper _mapper;

        public CompanyBs(ICompanyRepository repo, IMapper mapper)
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
           var company = await _repo.GetByIdAsync(id);
            if (company != null)
            {
                await _repo.DeleteAsync(company);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Silinecek olan içerik bulunamadı");

            
        }


        public async Task<ApiResponse<CompanyGetDto>> GetByCompanyByNameAsync(string name, params string[] includeList)
        {
            name = name.Trim();
            if (name.Length < 1 || name == null)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz");
            }
            var company = await _repo.GetByNameAsync(name, includeList);
            if (company != null)
            {
                var dto = _mapper.Map<CompanyGetDto>(company);
                return ApiResponse<CompanyGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<CompanyGetDto>>> GetCompanyAsync(params string[] includeList)
        {
            var companies = await _repo.GetAllAsync(includeList: includeList);
            if (companies != null && companies.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyGetDto>>(companies);
                var response = ApiResponse<List<CompanyGetDto>>.Success(StatusCodes.Status200OK, returnList);
                return response;
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByAdressAsync(string adress, params string[] includeList)
        {
            adress = adress.Trim();
            if (adress.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var companies = await _repo.GetByWebsiteAsync(adress, includeList);
            if (companies != null && companies.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyGetDto>>(companies);
                return ApiResponse<List<CompanyGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByDescriptionAsync(string description, params string[] includeList)
        {
            description = description.Trim();
            if (description.Length < 1)
            {
                throw new BadRequestException("En az 1 karakter girmelisiniz.");
            }
            var companies = await _repo.GetByDescriptionAsync(description, includeList);
            if (companies != null && companies.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyGetDto>>(companies);
                return ApiResponse<List<CompanyGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<CompanyGetDto>> GetCompanyByIdAsync(int id, params string[] includeList)
        {

            if (id <= 0)
            {
                throw new BadRequestException("Id değeri 0'dan büyük olmalıdır.");
            }
            var company = await _repo.GetByIdAsync(id, includeList);
            if (company != null)
            {
                var dto = _mapper.Map<CompanyGetDto>(company);
                return ApiResponse<CompanyGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İçerik Bulunamadı.");
        }

        public async Task<ApiResponse<List<CompanyGetDto>>> GetCompanyByWebsiteAsync(string website, params string[] includeList)
        {
            var companies = await _repo.GetByWebsiteAsync(website, includeList);
            if (companies != null && companies.Count > 0)
            {
                var returnList = _mapper.Map<List<CompanyGetDto>>(companies);
                return ApiResponse<List<CompanyGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException("İçerik Bulunamadı");
        }

        public async Task<ApiResponse<Company>> InsertAsync(CompanyPostDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek şirket bilgileri bulunamadı.");
            }
            dto.CompanyName = dto.CompanyName.Trim();
            dto.CompanyDescription = dto.CompanyDescription.Trim();
            if (dto.CompanyName.Length < 2 || dto.CompanyDescription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek şirket ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var company = _mapper.Map<Company>(dto);
            var insertedCompany = await _repo.InsertAsync(company);
            return ApiResponse<Company>.Success(StatusCodes.Status201Created, insertedCompany);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(CompanyPutDto dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Kaydedilecek şirket bilgilerini yollamalısınız.");
            }
            if (dto.CompanyId <= 0)
            {
                throw new BadRequestException("CategoryId değeri 0'dan büyük olmalıdır.");
            }
            dto.CompanyName = dto.CompanyName.Trim();
            dto.CompanyDescription = dto.CompanyDescription.Trim();
            if (dto.CompanyName.Length < 2 || dto.CompanyDescription.Length < 2)
            {
                throw new BadRequestException("Kaydedilecek şirket ismi ve açıklama kısmı en az 2 karakter uzunluğunda olmalıdır.");
            }
            var company = _mapper.Map<Company>(dto);
            await _repo.UpdateAsync(company);
            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
