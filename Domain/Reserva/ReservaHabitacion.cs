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
        public Guid ApplicationUserId { get; set; }
        public int HabitacionId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Habitacion Habitacion { get; set; }

    }
}
