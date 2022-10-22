using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaApi.Models.Dtos
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
