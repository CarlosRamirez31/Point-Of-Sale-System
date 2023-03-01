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
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}
