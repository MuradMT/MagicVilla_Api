using MagicVilla_VillaApi.Models.Dtos;
using System.Xml.Linq;

namespace MagicVilla_VillaApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>()
        {
                new VillaDto() { Name = "Balaxani", Id = 1,Occupancy=3,Sqft=100},
                new VillaDto() { Id = 2,Name = "Mastaga",Occupancy=4,Sqft=300}
        };
    
    }
}
