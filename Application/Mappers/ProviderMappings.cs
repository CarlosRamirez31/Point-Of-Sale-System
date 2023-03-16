using Application.Dtos.Provider.Request;
using Application.Dtos.Provider.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Responses;
using Utilities.Static;

namespace Application.Mappers
{
    public class ProviderMappings : Profile
    {
        public ProviderMappings()
        {
            CreateMap<Provider, ProviderResponseDto>()
                .ForMember(x => x.StateProvider, x => x.MapFrom(y => y.State.Equals(StateType.Activo) ? "Activo" : "Inactivo"))
                .ForMember(x => x.providerId, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Provider>, BaseEntityResponse<ProviderResponseDto>>()
                .ReverseMap();

            CreateMap<ProviderRequestDto, Provider>();
        }
    }
}
