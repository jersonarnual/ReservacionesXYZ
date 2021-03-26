using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XYZ.Domain
{
    public class TipoHotel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Hotel> ListHoteles { get; set; }
    }
}
