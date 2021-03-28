using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XYZ.Domain;
using XYZ.Domain.UserAuthentication;

namespace XYZ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Habitacion> Habitacion { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<PrecioHabitacion> PrecioHabitacion { get; set; }
        public DbSet<Temporada> Temporada { get; set; }
        public DbSet<TipoHabitacion> TipoHabitacion { get; set; }
        public DbSet<ReservaHabitacion> ReservaHabitacion { get; set; }
        public DbSet<ApplicationUser> Client { get; set; }
        public DbSet<TipoHotel> TipoHotel { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<EstadoReserva> EstadoReserva { get; set; }
    }
}
