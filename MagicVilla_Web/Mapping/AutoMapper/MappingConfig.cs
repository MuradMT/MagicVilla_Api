using AutoMapper;
using MagicVilla_Web.Models.Dtos;

namespace MagicVilla_Web.Mapping.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
            CreateMap<VillaCreateDto, VillaDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();
           

        }
    }
}
