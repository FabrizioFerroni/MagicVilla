﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_MVC.Models.Dto
{
    public class VillaCreateDto
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Maximo de 30 caracteres")]
        public String Nombre { get; set; } = "";
        [Required(ErrorMessage = "El Detalle es requerido")]
        public String Detalle { get; set; } = "";
        [Required(ErrorMessage = "La tarifa es requerida")]
        public Double Tarifa { get; set; } = 0.0;
        [Required(ErrorMessage = "La cantidad de ocupantes es requerida")]
        public int Ocupantes { get; set; }
        [Required(ErrorMessage = "Los metros cuadrados son requeridos")]
        public int MetrosCuadrados { get; set; }
        public String? ImagenUrl { get; set; } = "";
        public String? Amenidad { get; set; } = "";
    }
}
