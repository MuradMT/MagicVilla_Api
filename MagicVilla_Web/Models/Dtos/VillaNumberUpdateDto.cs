﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.Dtos
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string SpecialDetails { get; set; }
    }
}
