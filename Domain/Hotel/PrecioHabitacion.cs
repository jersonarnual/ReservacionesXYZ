using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XYZ.Domain
{
    public class PrecioHabitacion: BaseEntity
    {
        public Guid Id { get; set; }
        public int Precio { get; set; }
        public Guid TemporadaId { get; set; }
        public Guid TipoHabitacionId { get; set; }
        public virtual Temporada Temporada { get; set; }
        public virtual TipoHabitacion TipoHabitaciones { get; set; }

    }
}
