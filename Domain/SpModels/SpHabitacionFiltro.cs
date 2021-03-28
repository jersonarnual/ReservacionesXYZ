using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XYZ.Domain.SpModels
{
    public class SpHabitacionFiltro
    {
        public Guid IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public int IdHabitacion { get; set; }
        public string NombreHabitacion { get; set; }
        public Guid TemporadaId { get; set; }
        public string NombreTemporada { get; set; }
        public int Tarifa { get; set; }
        public int Capacidad { get; set; }
        public string DescripcionHabitacion { get; set; }
        public Guid IdTipoHabitacion { get; set; }
        public string FechaEntrega { get; set; }
        public string FechaSalida { get; set; }
    }
}
