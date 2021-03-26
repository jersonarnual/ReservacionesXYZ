using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;

namespace XYZ.Models
{
    public class TipoHabitacionViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Camas { get; set; }
        public int Capacidad { get; set; }
        public int Banhio { get; set; }
        public bool Salon { get; set; }
        public bool Terraza { get; set; }
        public IEnumerable<TipoHabitacion> ListTipoHabitaciones { get; set; }
    }
}
