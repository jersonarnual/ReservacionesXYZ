using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain;
using XYZ.Domain.SpModels;

namespace XYZ.Models
{
    public class HomeViewModel
    {
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Excedente { get; set; }
        public int Valor { get; set; }
        public int CantidadPersona { get; set; }
        public int CapacidadHabitacion { get; set; }
        public int HabitacionId { get; set; }
        public Guid HotelId { get; set; }
        public int EstadoReservaId { get; set; }
        public string ClientId { get; set; }
        public IEnumerable<Hotel> ListHoteles{ get; set; }
        public IEnumerable<SpHabitacionFiltro> ListHabitacionDisponibles { get; set; }
    }
    public class HabitacionTipoViewModel : HomeViewModel
    {
        
    }

}
