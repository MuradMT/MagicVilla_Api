using MagicVilla_VillaApi.Models;
using MagicVilla_VillaApi.Models.Dtos;

namespace MagicVilla_VillaApi.Mapping
{
    public static class Map
    {
        public static Villa VillaMapper(VillaDto villaDto)
        {
            Villa model = new Villa()
            {
                Name = villaDto.Name,
                Id = villaDto.Id,
                Sqft = villaDto.Sqft,
                Amenity = villaDto.Amenity,
                Details = villaDto.Details,
                ImageUrl = villaDto.ImageUrl,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate
            };
            return model;
        }
        public static VillaDto VillaDtoMapper(Villa villa)
        {
            VillaDto model = new VillaDto()
            {
                Name = villa.Name,
                Id = villa.Id,
                Sqft = villa.Sqft,
                Amenity = villa.Amenity,
                Details = villa.Details,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate
            };
            return model;
        }
    }
}
