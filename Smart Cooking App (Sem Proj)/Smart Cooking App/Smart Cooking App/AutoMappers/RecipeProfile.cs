using AutoMapper;
using Smart_Cooking_App.Models;
using Smart_Cooking_App.ViewModels;

namespace Smart_Cooking_App.AutoMappers
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath));
        }
    }
}

