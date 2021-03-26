using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;

namespace XYZ.Models
{
    public class PrecioHabitacionViewModel
    {
        public Guid Id { get; set; }
        public int Precio { get; set; }
        public Guid TemporadaId { get; set; }
        public Guid TipoHabitacionId { get; set; }
        public SelectList ListTemporadas { get; set; }
        public SelectList ListTipoHabitaciones { get; set; }
        public IEnumerable<PrecioHabitacion> ListPrecioHabitaciones { get; set; }

    }
}
