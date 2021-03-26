using System;
using System.Collections.Generic;

namespace XYZ.Domain
{
    public class TipoHabitacion : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Camas { get; set; }
        public int Capacidad { get; set; }
        public int Banhio { get; set; }
        public bool Salon { get; set; }
        public bool Terraza { get; set; }
        public virtual ICollection<PrecioHabitacion> PrecioHabitaciones { get; set; }
    }
}
