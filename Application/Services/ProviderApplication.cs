using Application.Commons.Base.Response;
using Application.Dtos.Provider.Response;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class ProviderApplication : IProviderApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BaseResponse<BaseEntityResponse<ProviderResponseDto>>> ListProvider(BaseFiltersRequest filter)
        {
            var response = new BaseResponse<BaseEntityResponse<ProviderResponseDto>>();
            var provider = await _unitOfWork.Provider.ListProvider(filter);

            if(provider.TotalRecords != (int)ItemStatus.Empty)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProviderResponseDto>>(provider);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
    }
}
