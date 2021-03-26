using System;
using System.Collections.Generic;

namespace XYZ.Domain
{
    public class Habitacion : BaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Disponibilidad { get; set; }
        public Guid TipoHabitacionId { get; set; }
        public Guid HotelId { get; set; }
        public virtual TipoHabitacion TipoHabitacion { get; set; }
        public virtual Hotel Hotel { get; set; }
        public ICollection<ReservaHabitacion> ReservaHabitacion { get; set; }
    }
}
