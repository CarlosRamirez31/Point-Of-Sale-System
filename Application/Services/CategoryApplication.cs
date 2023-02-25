using Application.Commons.Base.Response;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Application.Interfaces;
using Application.Validators.Category;
using AutoMapper;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Repositories;

namespace Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CategoryValidation _validationRules;

        public CategoryApplication(UnitOfWork unitOfWork, IMapper mapper, CategoryValidation validationRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategory(BaseFiltersRequest filters)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategory()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<CategoryResponseDto>> CategoryById(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto categoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> EditCategory(int CategoryId, CategoryRequestDto categoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<bool>> RemoveCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
