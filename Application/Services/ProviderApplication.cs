using Application.Commons.Base.Response;
using Application.Dtos.Provider.Response;
using Application.Interfaces;
using AutoMapper;
using Azure;
using Domain.Entities;
using Infrastructure.Commons.Bases.Requests;
using Infrastructure.Commons.Bases.Responses;
using Infrastructure.Persistences.Contexts;
using Infrastructure.Persistences.Interfaces;
using Utilities.Static;

namespace Application.Services
{
    public class ProviderApplication : IProviderApplication
    {
        private readonly PosContext _context;
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
        public async Task<BaseResponse<ProviderResponseDto>> GetByIdProvider(int id)
        {
            var response = new BaseResponse<ProviderResponseDto>();
            var provider = await _unitOfWork.Provider.GetByIdAsync(id, x => x.DocumentType);

            if(provider is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<ProviderResponseDto>(provider);
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
