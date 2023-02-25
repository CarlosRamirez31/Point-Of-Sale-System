using Application.Commons.Base.Response;
using Application.Dtos.Request;
using Application.Dtos.Response;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;

namespace Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDto>>> ListCategory(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDto>>> ListSelectCategory();
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int CategoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto categoryRequest);
        Task<BaseResponse<bool>> EditCategory(int CategoryId, CategoryRequestDto categoryRequest);
        Task<BaseResponse<bool>> RemoveCategory(int CategoryId);
    }
}
