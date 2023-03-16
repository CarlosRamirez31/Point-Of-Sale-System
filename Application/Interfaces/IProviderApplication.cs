using Application.Commons.Base.Response;
using Application.Dtos.Provider.Response;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;

namespace Application.Interfaces
{
    public interface IProviderApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProviderResponseDto>>> ListProvider(BaseFiltersRequest filter);
    }
}
