using System;
using System.Collections.Generic;

namespace XYZ.Domain
{
    public class Temporada : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<PrecioHabitacion> PrecioHabitaciones { get; set; }
    }
}
