using AutoMapper;
using PB102App.Models;
using PB102App.ViewModels.Admin.Slider;
using PB102App.ViewModels.Admin.Work;

namespace PB102App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderVM>();
            CreateMap<SliderImage, SliderImageVM>();
            CreateMap<Work, WorkVM>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                    .ForMember(dest => dest.MainImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault(m => m.IsMain).Image));

            CreateMap<Work, SingleWorkVM>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
