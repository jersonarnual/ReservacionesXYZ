using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;

namespace XYZ.Models
{
    public class HotelViewModel
    {
        [Display(Name = "Identificador del hotel")]
        public Guid Id { get; set; }
        [Display(Name ="Nombre Hotel")]
        public string Nombre { get; set; }
        [Display(Name = "Calificacion Del Hotel")]
        public int Calificacion { get; set; }
        public IEnumerable<Hotel> listHotelViewModels { get; set; }
    }
}
