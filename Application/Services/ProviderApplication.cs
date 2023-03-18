using Application.Commons.Base.Response;
using Application.Dtos.Provider.Request;
using Application.Dtos.Provider.Response;
using Application.Interfaces;
using Application.Validators.Provider;
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
        private readonly ProviderValidator _validationsRules;

        public ProviderApplication(IUnitOfWork unitOfWork, IMapper mapper, ProviderValidator validationsRules)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationsRules = validationsRules;
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

        public async Task<BaseResponse<bool>> RegisterProvider(ProviderRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validation = _validationsRules.Validate(requestDto);

            if (!validation.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validation.Errors;
                return response;
            }

            var provider = _mapper.Map<Provider>(requestDto);
            response.Data = await _unitOfWork.Provider.RegisterAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditProvider(int id, ProviderRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var providerById = await GetByIdProvider(id);

            if(providerById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
                return response;
            }

            var validation = _validationsRules.Validate(requestDto);
            
            if (!validation.IsValid)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_VALIDATE;
                response.Errors = validation.Errors;
                return response;
            }

            var provider = _mapper.Map<Provider>(requestDto);
            provider.Id = id;
            response.Data = await _unitOfWork.Provider.EditAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXISTS;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> RemoveProvider(int id)
        {
            var response = new BaseResponse<bool>();
            var providerById = await GetByIdProvider(id);

            if(providerById.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
                return response;
            }

            response.Data = await _unitOfWork.Provider.RemoveAsync(1);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_DELETE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILED;
            }
            return response;
        }
    }
}
