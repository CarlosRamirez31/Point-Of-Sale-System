using Application.Commons.Base.Response;
using Application.Dtos.Request;
using Application.Dtos.Response;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Responses;
using Utilities.Static;

namespace Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.CategoryState, x => x.MapFrom(y => y.State.Equals((int)StateType.Activo) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<Category, CategorySelectResponseDto>()
                .ReverseMap();
            
            CreateMap<CategoryRequestDto, Category>();
        }
    }
}
