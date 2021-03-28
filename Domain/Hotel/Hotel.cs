using System;
using System.Collections.Generic;

namespace XYZ.Domain
{
    public class Hotel : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CupoMaximo { get; set; }
        public Guid TipoHotelId { get; set; }
        public int CiudadId { get; set; }
        public ICollection<Habitacion> Habitaciones { get; set; }
        public virtual TipoHotel TipoHotel { get; set; }
        public virtual Ciudad Ciudad { get; set; }
    }
}
