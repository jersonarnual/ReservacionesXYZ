using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XYZ.Domain;

namespace XYZ.Models
{
    public class HotelViewModel
    {
        [Display(Name = "Identificador del hotel")]
        public Guid Id { get; set; }
        [Display(Name ="Nombre Hotel")]
        public string Nombre { get; set; }
        [Display(Name = "Descripcion")]
        public string  Descripcion { get; set; }
        public int CupoMaximo { get; set; }
        public Guid TipoHotelId { get; set; }
        public int CiudadId { get; set; }
        public SelectList ListTipoHotel { get; set; }
        public SelectList ListCiudades { get; set; }
        public IEnumerable<Hotel> listHotelViewModels { get; set; }
    }
}
