using System;
using System.ComponentModel.DataAnnotations.Schema;
using XYZ.Domain.UserAuthentication;

namespace XYZ.Domain
{
    public class ReservaHabitacion : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Excedente { get; set; }
        public int HabitacionId { get; set; }
        public string ClientId { get; set; }
        public virtual Habitacion Habitacion { get; set; }
        [ForeignKey("ClientId")]
        public virtual ApplicationUser Client { get; set; }

    }
}
