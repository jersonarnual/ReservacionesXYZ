using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Data;
using XYZ.Domain;

namespace XYZ.Services
{
    public interface IHabitacionService
    {
        Task<bool> RegistrarHabitacion(Habitacion model);
        Task<bool> ActualizarHabitacion(Habitacion model);
        Habitacion GetHabitacionById(int id);
        IEnumerable<Habitacion> GetAllHabitacion();
    }
    public class HabitacionService : IHabitacionService
    {
        #region Miembros
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public HabitacionService(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        #endregion
        #region Metodos
        public async Task<bool> ActualizarHabitacion(Habitacion model)
        {
            try
            {
                _context.Habitacion.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Habitacion> GetAllHabitacion()
        {
            return _context.Habitacion.ToList();
        }

        public Habitacion GetHabitacionById(int id)
        {
            Habitacion model = null;
            if (id > 0)
            {
                var habitacion = _context.Habitacion.Find(id);
                model = new Habitacion()
                {
                    Id = habitacion.Id,
                    Nombre = habitacion.Nombre,
                    TipoHabitacionId = habitacion.TipoHabitacionId,
                    HotelId=habitacion.HotelId
                };
            }
            return model;
        }

        public async Task<bool> RegistrarHabitacion(Habitacion model)
        {
            try
            {
                await _context.Habitacion.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
