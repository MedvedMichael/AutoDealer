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
            CreateMap<Generation, GenerationDto>();
            CreateMap<Engine, EngineDto>();
            CreateMap<Gearbox, GearboxDto>().ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GearboxType));
            CreateMap<Equipment, BaseAutoDto>();
            CreateMap<ModelDto, Model>();
            CreateMap<string, Generation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));

            CreateMap<User, UserProfile>();


            CreateMap<SaleAnnouncement, SaleAnnouncementDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => new Car
                {
                    Brand = new BaseAutoDto { Id = src.Model.BrandId, Name = src.Model.Brand.Name },
                    Model = new BaseAutoDto { Id = src.Model.Id, Name = src.Model.Name },
                    Generation = new GenerationDto { Id = src.Generation.Id, Name = src.Generation.Name, StartYear = src.Generation.StartYear, EndYear = src.Generation.EndYear },
                    Engine = new EngineDto { Id = src.Engine.Id, Name = src.Engine.Name, FuelType = src.Engine.FuelType, Capacity = src.Engine.Capacity, HorsePower = src.Engine.HorsePower },
                    Equipment = new BaseAutoDto { Id = src.Equipment.Id, Name = src.Equipment.Name },
                    Gearbox = new GearboxDto { Id = src.Gearbox.Id, Name = src.Gearbox.Name, Type = src.Gearbox.GearboxType },
                    Year = src.Year,
                    Color = src.Color,
                    OwnersCount = src.OwnersCount,
                    WinNumber = src.WinNumber,
                    Mileage = src.MileageThousands,
                }))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => new UserProfile
                {
                    Id = src.User.Id,
                    Name = src.User.Name,
                    Surname = src.User.Surname,
                    Email = src.User.Email,
                }));


        }
    }
}