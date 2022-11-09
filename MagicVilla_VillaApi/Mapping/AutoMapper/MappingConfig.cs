using AutoMapper;
using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dtos;

namespace MagicVilla_VillaApi.Mapping.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();
            CreateMap<VillaCreateDto, Villa>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
            CreateMap<VillaNumberCreateDto, VillaNumber>().ReverseMap();
            CreateMap<VillaNumberCreateDto, Villa>().ReverseMap();
            CreateMap<RegistrationRequestDto, LocalUser>().ReverseMap();

        }
    }
}
