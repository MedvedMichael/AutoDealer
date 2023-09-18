using AutoDealer.Entities.DataTransferObjects.Auth;
using AutoDealer.Entities.DataTransferObjects.Auto;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.Entities.Models.Auto;
using AutoMapper;

namespace AutoDealer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<Brand, BaseAutoDto>();
            CreateMap<Model, BaseAutoDto>();
            CreateMap<Generation, BaseAutoDto>();
            CreateMap<ModelDto, Model>();
            CreateMap<string, Generation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));

        }
    }
}