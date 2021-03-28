using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;

namespace XYZ.Models
{
    public class HabitacionViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Guid TipoHabitacionId { get; set; }
        public Guid HotelId { get; set; }
        public SelectList ListaTipoHabitacion { get; set; }
        public SelectList ListaHoteles { get; set; }
        public IEnumerable<Habitacion> ListHabitaciones { get; set; }
        public Hotel Hotel { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
    }
}
