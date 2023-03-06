using Application.Commons.Base.Response;
using Application.Dtos.Category.Request;
using Application.Dtos.Category.Response;
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
                .ForMember(x => x.CategoryId, x => x.MapFrom(x => x.Id))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<Category, CategorySelectResponseDto>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(x => x.Id))
                .ReverseMap();
            
            CreateMap<CategoryRequestDto, Category>();
        }
    }
}
